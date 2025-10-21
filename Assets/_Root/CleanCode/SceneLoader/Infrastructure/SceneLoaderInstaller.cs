using System.Collections.Generic;
using _Root.CleanCode.Shared.Ports.SceneLoader;
using Zenject;

namespace _Root.CleanCode.SceneLoader.Infrastructure
{
    public class SceneLoaderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle().WithArguments(new []{"UIScene"}).NonLazy();
        }
    }
}