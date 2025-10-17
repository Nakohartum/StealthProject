using _Root.CleanCode.Dialog.Application;
using _Root.CleanCode.Dialog.Application.Ports;
using _Root.CleanCode.Dialog.Domain;
using _Root.CleanCode.Shared.Ports.Dialog;
using Zenject;

namespace _Root.CleanCode.Dialog.Infrastructure
{
    public class DialogInstaller : MonoInstaller
    {
        public DialogCatalog DialogCatalog;
        public override void InstallBindings()
        {
            Container.Bind<DialogState>().AsSingle();
            Container.BindInterfacesTo<DialogPort>().AsSingle().NonLazy();
            
            Container.Bind<StartDialogUseCase>().AsSingle();
            Container.Bind<TypeNextLineUseCase>().AsSingle();
            Container.Bind<TryProceedToNextLineUseCase>().AsSingle();
            Container.Bind<TypingUseCase>().AsSingle();
            
            Container.Bind<DialogCatalog>().FromInstance(DialogCatalog).AsSingle();
            Container.Bind<IDialogView>().FromComponentInHierarchy().AsSingle();
        }
    }
}