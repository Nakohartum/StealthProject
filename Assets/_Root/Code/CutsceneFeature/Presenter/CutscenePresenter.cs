using _Root.Code.CutsceneFeature.Model;
using _Root.Code.CutsceneFeature.View;

namespace _Root.Code.CutsceneFeature.Presenter
{
    public class CutscenePresenter
    {
        private CutsceneView _cutsceneView;
        private CutsceneModel _cutsceneModel;

        public CutscenePresenter(CutsceneView cutsceneView, CutsceneModel cutsceneModel)
        {
            _cutsceneView = cutsceneView;
            _cutsceneModel = cutsceneModel;
        }

        public void Start()
        {
            ShowCurrent();
        }

        public void OnNextStep()
        {
            if (!_cutsceneModel.NextStep())
            {
                _cutsceneView.EndCutscene();
                return;
            }
            ShowCurrent();
        }

        private void ShowCurrent()
        {
            var step = _cutsceneModel.GetCurrentCutscenePart();
            _cutsceneView.ShowStep(step);
        }
    }
}