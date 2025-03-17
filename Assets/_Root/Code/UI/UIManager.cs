using System;
using _Root.Code.CutsceneFeature;
using _Root.Code.CutsceneFeature.View;
using _Root.Code.UI.Dialog;
using _Root.Code.UI.MainMenu;
using UnityEngine;
using Zenject;

namespace _Root.Code.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("UI Root")]
        [SerializeField] private Transform _uiRoot;
        
        [Header("Dialog Prefab")]
        [SerializeField] private DialogView _dialogView;
        
        [Header("Main Menu Prefab")]
        [SerializeField] private MainMenuView _mainMenuView;
        
        [Header("Cutscene Prefab")]
        [SerializeField] private CutsceneView _cutsceneView;
        
        [Header("Quest Prefab")]
        [SerializeField] private QuestView _questView;
        [SerializeField] private QuestPartView _questPartViewPrefab;
        
        private DialogViewCreator _dialogViewCreator;
        private MainMenuCreator _mainMenuCreator;
        private CutsceneCreator _cutsceneCreator;
        private QuestViewCreator _questViewCreator;
        [Inject] private SignalBus _signalBus;
        

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _dialogViewCreator = new DialogViewCreator(_dialogView, _signalBus);
            _mainMenuCreator = new MainMenuCreator(_mainMenuView, _signalBus);
            _cutsceneCreator = new CutsceneCreator(_cutsceneView, _signalBus);
            _questViewCreator = new QuestViewCreator(_questView, _questPartViewPrefab);
        }

        public QuestView CreateQuestView()
        {
            return _questViewCreator.CreateQuestView(_uiRoot);
        }

        public QuestPartView CreateQuestPartView(RectTransform root)
        {
            return _questViewCreator.CreateQuestPartView(root);
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
}