using System;
using _Root.Code.MainMenuFeature.View;
using _Root.Code.Miscellanious;
using UnityEngine;
using Zenject;

namespace _Root.Code.MainMenuFeature.Presenter
{
    public class MainMenuPresenter : IDisposable
    {
        private MainMenuView _view;
        private GlobalManagers.LevelManager _levelManager;
        
        public MainMenuPresenter(MainMenuView view, GlobalManagers.LevelManager levelManager)
        {
            _view = view;
            _levelManager = levelManager;
            SubscribeToButtons();
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
            _levelManager.InitLevel(InGameStrings.FIRST_LEVEL);
            UnityEngine.Object.Destroy(_view.gameObject);
            Dispose();
        }

        public void Dispose()
        {
            _view.StartGameButton.Button.onClick.RemoveAllListeners();
            _view.ExitGameButton.Button.onClick.RemoveAllListeners();
        }
    }
}