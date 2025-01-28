using _Root.Code.UI;
using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private DialogView _dialogView;
    public override void InstallBindings()
    {
        Container.Bind<DialogController>().AsSingle().WithArguments(_dialogView).NonLazy();
    }
}