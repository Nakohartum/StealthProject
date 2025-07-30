using _Root.Code.Input;
using UnityEngine;
using Zenject;

namespace _Root.Code.Installers
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
                Container.BindInterfacesAndSelfTo<InputController>().AsSingle().WithArguments(Time.deltaTime).NonLazy();
        }
    }
}