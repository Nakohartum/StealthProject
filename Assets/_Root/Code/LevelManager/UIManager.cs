using _Root.Code.UI;
using _Root.Code.UI.MainMenu;
using UnityEngine;
using Zenject;

namespace _Root.Code.LevelManager
{
    public class UIManager
    {
        private Transform _uiRoot;
        private DialogViewCreator _dialogViewCreator;
        private MainMenuCreator _mainMenuCreator;
        private SignalBus _signalBus;
        
        [Inject]
        public UIManager(Transform uiRoot, DialogView dialogView, MainMenuView mainMenuView, SignalBus signalBus)
        {
            _uiRoot = uiRoot;
            _signalBus = signalBus;
            _dialogViewCreator = new DialogViewCreator(dialogView, _signalBus);
            _mainMenuCreator = new MainMenuCreator(mainMenuView, _signalBus);
        }

        public void CreateDialogView()
        {
            _dialogViewCreator.CreateDialogView(_uiRoot);
        }

        public void CreateMainMenu()
        {
            _mainMenuCreator.CreateMainMenu(_uiRoot);
        }

        public void DestroyDialogView()
        {
            _dialogViewCreator.DestroyDialogView();
        }

        public void DestroyMainMenu()
        {
            _mainMenuCreator.DestroyMainMenu();
        }
    }
}