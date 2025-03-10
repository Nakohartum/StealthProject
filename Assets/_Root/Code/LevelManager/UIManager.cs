using _Root.Code.CutsceneFeature.View;
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
        private CutsceneCreator _cutsceneCreator;
        private SignalBus _signalBus;
        
        [Inject]
        public UIManager(Transform uiRoot, DialogView dialogView, MainMenuView mainMenuView, CutsceneView cutsceneView, SignalBus signalBus)
        {
            _uiRoot = uiRoot;
            _signalBus = signalBus;
            _dialogViewCreator = new DialogViewCreator(dialogView, _signalBus);
            _mainMenuCreator = new MainMenuCreator(mainMenuView, _signalBus);
            _cutsceneCreator = new CutsceneCreator(cutsceneView, _signalBus);
        }

        public void CreateCutsceneView()
        {
            _cutsceneCreator.CreateCutsceneView(_uiRoot);
        }

        public void DestroyCutsceneView()
        {
            _cutsceneCreator.DestroyCutsceneView();
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

    internal class CutsceneCreator
    {
        private CutsceneView _cutscenePrefab;
        private CutsceneView _currentCutsceneView;
        private SignalBus _signalBus;
        
        public CutsceneCreator(CutsceneView cutscenePrefab, SignalBus signalBus)
        {
            _cutscenePrefab = cutscenePrefab;
            _signalBus = signalBus;
        }

        public void CreateCutsceneView(Transform root)
        {
            if (_currentCutsceneView != null)
            {
                return;
            }
            
            _currentCutsceneView = Object.Instantiate(_cutscenePrefab, root);
            _signalBus.Fire(new CutsceneCreatedSignal
            {
                CutsceneView = _currentCutsceneView
            });
        }

        public void DestroyCutsceneView()
        {
            if (_currentCutsceneView == null) return;
            Object.Destroy(_currentCutsceneView.gameObject);
            _currentCutsceneView = null;
        }
    }
    class CutsceneCreatedSignal
    {
        public CutsceneView CutsceneView;
    }
}