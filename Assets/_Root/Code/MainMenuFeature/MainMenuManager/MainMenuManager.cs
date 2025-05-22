using _Root.Code.GlobalMusicFeature.GlobalMusicPresenter;
using _Root.Code.MainMenuFeature.Presenter;
using _Root.Code.MainMenuFeature.View;
using UnityEngine;
using Zenject;

namespace _Root.Code.MainMenuFeature.MainMenuManager
{
    public class MainMenuManager
    {
        private GlobalManagers.LevelManager _levelManager;
        private MainMenuView.Factory _mainMenuViewFactory;
        private readonly GlobalMusicPresenter _musicPresenter;
        private AudioClip _mainMenuMusic;

        [Inject]
        public MainMenuManager(GlobalManagers.LevelManager levelManager, MainMenuView.Factory mainMenuViewFactory, GlobalMusicPresenter musicPresenter, AudioClip mainMenuMusic)
        {
            _levelManager = levelManager;
            _mainMenuViewFactory = mainMenuViewFactory;
            _musicPresenter = musicPresenter;
            _mainMenuMusic = mainMenuMusic;
        }

        public void OpenMainMenu()
        {
            var mainMenuView = _mainMenuViewFactory.Create();
            var mainMenuPresenter = new MainMenuPresenter(mainMenuView, _levelManager, _musicPresenter, _mainMenuMusic);
        }
    }
}