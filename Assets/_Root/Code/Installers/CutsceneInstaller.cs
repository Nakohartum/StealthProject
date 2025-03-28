using _Root.Code.CutsceneFeature.Manager;
using _Root.Code.CutsceneFeature.Model;
using _Root.Code.CutsceneFeature.View;
using UnityEngine;
using Zenject;

namespace _Root.Code.Installers
{
    public class CutsceneInstaller : MonoInstaller
    {
        [SerializeField] private Transform _cutsceneRoot;
        [SerializeField] private CutsceneView _cutscenePrefab;
        [SerializeField] private CutsceneRegistry _cutsceneRegistry;
        public override void InstallBindings()
        {
            Container.BindFactory<CutsceneView, CutsceneView.CutsceneFactory>().FromComponentInNewPrefab(_cutscenePrefab).UnderTransform(_cutsceneRoot);
            Container.Bind<CutsceneManager>().AsSingle().WithArguments(_cutsceneRegistry);
        }
    }
}