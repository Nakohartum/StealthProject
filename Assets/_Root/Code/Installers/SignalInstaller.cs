using _Root.Code.LevelFeature;
using _Root.Code.Signals;
using Zenject;

namespace _Root.Code.Installers
{
    public class SignalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<PlayerFactoryCreatedSignal>();
            Container.BindSignal<PlayerFactoryCreatedSignal>()
                .ToMethod<LevelManager>(lm => lm.OnPlayerFactoryReady)
                .FromResolve();
        }
    }
}