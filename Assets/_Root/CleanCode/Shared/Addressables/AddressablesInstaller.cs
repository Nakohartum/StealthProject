using _Root.CleanCode.Shared.Ports;
using Zenject;

namespace Shared._Root.CleanCode.Shared
{
    public class AddressablesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IAddressablesPort>().To<AddressablesHelper>().AsSingle().NonLazy();
        }
    }
}