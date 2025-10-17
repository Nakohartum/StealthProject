using UnityEngine;
using Zenject;

namespace _Root.CleanCode.Room.Infrastructure
{
    [RequireComponent(typeof(RoomAdapter), typeof(GameObjectContext))]
    public class RoomInstaller : MonoInstaller
    {
        [SerializeField] private RoomAdapter _roomAdapter;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RoomAdapter>().FromInstance(_roomAdapter).AsSingle();
        }
    }
}