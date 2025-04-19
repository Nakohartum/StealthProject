using _Root.Code.FogOfWarFeature.Components;
using _Root.Code.FogOfWarFeature.Presenter;
using _Root.Code.RoomFeature.Model;
using _Root.Code.RoomFeature.Presenter;
using _Root.Code.RoomFeature.View;
using UnityEngine;
using Zenject;

namespace _Root.Code.RoomFeature.Installer
{
    public class RoomInstaller : MonoInstaller
    {
        [SerializeField] private RoomView _roomView;
        [SerializeField] private FogOfWar _fogOfWar;
        public override void InstallBindings()
        {
            var roomModel = new RoomModel();
            Container.Bind<RoomPresenter>().AsSingle().WithArguments(_roomView, roomModel).NonLazy();
            Container.Bind<FogOfWarPresenter>().AsSingle().WithArguments(_fogOfWar).NonLazy();
        }
    }
}