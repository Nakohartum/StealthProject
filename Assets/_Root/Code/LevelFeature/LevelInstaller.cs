using _Root.Code.Signals;
using Zenject;

namespace _Root.Code.LevelFeature
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<LevelManager>().AsSingle().NonLazy();
            
        }
    }
}