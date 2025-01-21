using _Root.Code.Input;
using GameOne.Player;
using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<float>().WithId("deltaTime").FromInstance(Time.deltaTime).AsSingle();
        Container.Bind<InputActions>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<InputController>().AsSingle();
    }
}