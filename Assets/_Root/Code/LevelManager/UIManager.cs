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
        private QuestViewCreator _questViewCreator;
        private SignalBus _signalBus;
        
        [Inject]
        public UIManager(Transform uiRoot, DialogView dialogView, MainMenuView mainMenuView, 
            CutsceneView cutsceneView, QuestView questView, SignalBus signalBus)
        {
            _uiRoot = uiRoot;
            _signalBus = signalBus;
            _dialogViewCreator = new DialogViewCreator(dialogView, _signalBus);
            _mainMenuCreator = new MainMenuCreator(mainMenuView, _signalBus);
            _cutsceneCreator = new CutsceneCreator(cutsceneView, _signalBus);
            _questViewCreator = new QuestViewCreator(questView);
        }

        public QuestView CreateQuestView()
        {
            return _questViewCreator.CreateQuestView(_uiRoot);
        }

        public void DestroyQuestView()
        {
            _questViewCreator.DestroyQuestView();
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


    internal class QuestViewCreator
    {
        private QuestView _questViewPrefab;
        private QuestView _currentQuestView;

        public QuestViewCreator(QuestView questViewPrefab)
        {
            _questViewPrefab = questViewPrefab;
        }
        
        public QuestView CreateQuestView(Transform root)
        {
            if (_currentQuestView != null)
            {
                return _currentQuestView;
            }
            
            _currentQuestView = Object.Instantiate(_questViewPrefab, root);
            return _currentQuestView;
        }

        public void DestroyQuestView()
        {
            if (_currentQuestView == null) return;
            Object.Destroy(_currentQuestView.gameObject);
            _currentQuestView = null;
        }
    }

    class CutsceneCreatedSignal
    {
        public CutsceneView CutsceneView;
    }
}