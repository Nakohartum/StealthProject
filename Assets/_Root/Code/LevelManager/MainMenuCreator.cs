using _Root.Code.UI.MainMenu;
using UnityEngine;
using Zenject;

namespace _Root.Code.LevelManager
{
    public class MainMenuCreator
    {
        private MainMenuView _mainMenuPrefab;
        private MainMenuView _currentMainMenu;
        private SignalBus _signalBus;
        
        public MainMenuCreator(MainMenuView mainMenuPrefab, SignalBus signalBus)
        {
            _mainMenuPrefab = mainMenuPrefab;
            _signalBus = signalBus;
        }

        public void CreateMainMenu(Transform root)
        {
            if (_currentMainMenu != null)
            {
                return;
            }
            _currentMainMenu = Object.Instantiate(_mainMenuPrefab, root);
        }

        public void DestroyMainMenu()
        {
            if (_currentMainMenu == null) return;
            Object.Destroy(_currentMainMenu.gameObject);
            _currentMainMenu = null;
        }
    }
}