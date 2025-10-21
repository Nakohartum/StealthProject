using _Root.CleanCode.InteractableFeature.Infrastructure;
using _Root.CleanCode.Player.Application;
using UnityEngine;
using Zenject;

namespace _Root.CleanCode.Player.Infrastructure
{
    [RequireComponent(typeof(PlayerTag))]
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerTag _playerTag;
        [SerializeField] private PhysicsCheckerAdapter _physicsCheckerAdapter;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerTag>().FromInstance(_playerTag).AsSingle();
            Container.BindInterfacesAndSelfTo<InteractiveObjectsCheckerSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PhysicsCheckerAdapter>().FromInstance(_physicsCheckerAdapter).AsSingle();
            
        }
    }
}