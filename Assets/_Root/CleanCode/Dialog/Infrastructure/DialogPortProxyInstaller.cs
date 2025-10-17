using Zenject;

namespace _Root.CleanCode.Dialog.Infrastructure
{
    public class DialogPortProxyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DialogPortProxy>().AsSingle().NonLazy();
        }
    }
}