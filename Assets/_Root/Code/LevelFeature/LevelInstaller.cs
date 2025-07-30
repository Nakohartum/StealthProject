using _Root.Code.Signals;
using Zenject;

namespace _Root.Code.LevelFeature
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<LevelManager>().AsSingle().NonLazy();
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<PlayerFactoryCreatedSignal>();
            Container.BindSignal<PlayerFactoryCreatedSignal>()
                .ToMethod<LevelManager>(lm => lm.OnPlayerFactoryReady)
                .FromResolve();
        }
    }
}