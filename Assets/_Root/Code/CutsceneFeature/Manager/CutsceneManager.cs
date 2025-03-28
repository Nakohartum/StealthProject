using _Root.Code.CutsceneFeature.Model;
using _Root.Code.CutsceneFeature.Presenter;
using _Root.Code.CutsceneFeature.View;
using Zenject;

namespace _Root.Code.CutsceneFeature.Manager
{
    public class CutsceneManager
    {
        private CutsceneView.CutsceneFactory _cutsceneFactory;
        private CutsceneRegistry _cutsceneRegistry;
        [Inject]
        public CutsceneManager(CutsceneView.CutsceneFactory cutsceneFactory, CutsceneRegistry cutsceneRegistry)
        {
            _cutsceneFactory = cutsceneFactory;
            _cutsceneRegistry = cutsceneRegistry;
        }
        public void StartCutscene(string cutsceneName)
        {
            var cutscene = _cutsceneRegistry[cutsceneName];
            var model = CreateCutsceneModel(cutscene);
            var view = _cutsceneFactory.Create();
            var presenter = CreateCutscenePrensenter(model, view);
            view.Construct(presenter);
            presenter.Start();
        }

        private CutscenePresenter CreateCutscenePrensenter(CutsceneModel model, CutsceneView view)
        {
            return new CutscenePresenter(view, model);
        }

        private CutsceneModel CreateCutsceneModel(CutsceneData cutscene)
        {
            return new CutsceneModel(cutscene);
        }
    }
}