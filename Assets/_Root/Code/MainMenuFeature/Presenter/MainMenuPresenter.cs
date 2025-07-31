using System;
using _Root.Code.GlobalMusicFeature.GlobalMusicPresenter;
using _Root.Code.MainMenuFeature.View;
using _Root.Code.Miscellanious;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace _Root.Code.MainMenuFeature.Presenter
{
    public class MainMenuPresenter : IDisposable
    {
        private MainMenuView _view;
        private GlobalMusicPresenter _globalMusicPresenter;
        private AudioClip _mainMenuMusic;
        private LevelFeature.SceneManager _sceneManager;
        
        public MainMenuPresenter(MainMenuView view, GlobalMusicPresenter globalMusicPresenter, AudioClip mainMenuMusic, LevelFeature.SceneManager sceneManager)
        {
            _view = view;
            _view.InitializeView(this);
            _globalMusicPresenter = globalMusicPresenter;
            _mainMenuMusic = mainMenuMusic;
            _sceneManager = sceneManager;
            SubscribeToButtons();
            _globalMusicPresenter.StartMusic(_mainMenuMusic, true);
            _sceneManager.SetCurrentScene(SceneNames.MainMenuScene);
        }

        private void SubscribeToButtons()
        {
            _view.StartGameButton.Button.onClick.AddListener(StartGame);
            _view.ExitGameButton.Button.onClick.AddListener(ExitGame);
        }

        private void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }

        private void StartGame()
        { 
            _globalMusicPresenter.StopMusic();
            
            _sceneManager.ChangeSceneAsync(SceneNames.FirstLevel, sceneMode: LoadSceneMode.Additive).Forget();
            
        }

        public void Dispose()
        {
            _view.StartGameButton.Button.onClick.RemoveAllListeners();
            _view.ExitGameButton.Button.onClick.RemoveAllListeners();
        }
    }
}