using _Root.Code.MainMenuFeature.Presenter;
using _Root.Code.MainMenuFeature.View;
using Zenject;

namespace _Root.Code.MainMenuFeature.MainMenuManager
{
    public class MainMenuManager
    {
        private GlobalManagers.LevelManager _levelManager;
        private MainMenuView.Factory _mainMenuViewFactory;

        [Inject]
        public MainMenuManager(GlobalManagers.LevelManager levelManager, MainMenuView.Factory mainMenuViewFactory)
        {
            _levelManager = levelManager;
            _mainMenuViewFactory = mainMenuViewFactory;
        }

        public void OpenMainMenu()
        {
            var mainMenuView = _mainMenuViewFactory.Create();
            var mainMenuPresenter = new MainMenuPresenter(mainMenuView, _levelManager);
        }
    }
}