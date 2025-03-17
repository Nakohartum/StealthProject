using _Root.Code.UI.Dialog;
using Cinemachine;
using GameOne.Player;
using UnityEngine;
using Zenject;

namespace _Root.Installers
{
    public class SignalsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<PlayerCreatedSignal>();
            Container.DeclareSignal<DialogCreatedSignal>();
        
        }
    }
}