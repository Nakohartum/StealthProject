using _Root.Code.CutsceneFeature.Model;
using _Root.Code.CutsceneFeature.View;
using _Root.Code.LevelManager;
using UnityEngine;
using Zenject;

namespace _Root.Code.CutsceneFeature.Controller
{
    public class CutsceneManager
    {
        private static CutsceneManager _instance;
        private UIManager _uiManager;
        private CutsceneView _cutsceneView;

        public static CutsceneManager Instance => _instance;

        [Inject]
        private CutsceneManager(UIManager uiManager, SignalBus signalBus)
        {
            _uiManager = uiManager;
            _instance = this;
            signalBus.Subscribe<CutsceneCreatedSignal>(Initialize);
        }

        private void Initialize(CutsceneCreatedSignal obj)
        {
            _cutsceneView = obj.CutsceneView;
        }

        public void StartCutscene(CutsceneSO cutscene)
        {
            _uiManager.CreateCutsceneView();
            Debug.Log("Cutscene Started");
        }
    }
}