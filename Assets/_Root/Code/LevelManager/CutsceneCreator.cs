using _Root.Code.CutsceneFeature.View;
using UnityEngine;
using Zenject;

namespace _Root.Code.LevelManager
{
    public class CutsceneCreator
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
}