using _Root.CleanCode.Shared.Ports.Input;
using UnityEngine;
using Zenject;

namespace _Root.CleanCode.Input.Infrastructure
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputPort>().To<InputPort>().AsSingle().NonLazy();
        }
    }
}