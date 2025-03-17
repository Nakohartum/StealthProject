using _Root.Code.UI;
using Zenject;

namespace _Root.Installers
{
    public class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<DialogController>().AsSingle().NonLazy();
        }
    }
}