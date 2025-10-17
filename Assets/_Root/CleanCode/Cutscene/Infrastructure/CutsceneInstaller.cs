using _Root.CleanCode.Cutscene.Application;
using _Root.CleanCode.Shared.Ports.Cutscene;
using UnityEngine;
using Zenject;

namespace _Root.CleanCode.Cutscene.Infrastructure
{
    /// <summary>Zenject installer for the Cutscene feature.</summary>
    public sealed class CutsceneInstaller : MonoInstaller
    {
        [Header("References")]
        [SerializeField] private CutsceneCatalogConfig _catalog;

        public override void InstallBindings()
        {
            // Catalog (config ScriptableObject implements ports)
            Container.Bind<ICutsceneCatalogPort>().FromInstance(_catalog).AsSingle();
            Container.Bind<ICutsceneCatalogRuntime>().FromInstance(_catalog).AsSingle();

            // Player (infrastructure)
            Container.BindInterfacesTo<TimelineCutscenePlayer>().AsSingle();

            // Use cases
            Container.Bind<StartCutscene>().AsSingle();
            Container.Bind<SkipCutscene>().AsSingle();

            // Facade as public API
            Container.Bind<ICutscenePort>().To<CutsceneFacade>().AsSingle();
            Container.Bind<CutsceneFacade>().AsSingle();
        }
    }
}