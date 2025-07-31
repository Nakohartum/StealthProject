using _Root.Code.LevelFeature;
using Zenject;

namespace _Root.Code.Installers
{
    public class SceneManagerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SceneManager>().AsSingle().NonLazy();
        }
    }
}