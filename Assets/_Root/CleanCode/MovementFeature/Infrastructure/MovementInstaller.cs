using _Root.CleanCode.MovementFeature.Application;
using _Root.CleanCode.MovementFeature.Domain;
using UnityEngine;
using Zenject;

namespace _Root.CleanCode.MovementFeature.Infrastructure
{
    [RequireComponent(typeof(MovementAdapter))]
    public class MovementInstaller : MonoInstaller
    {
        [SerializeField] private MovementAdapter _movementAdapter;
        [SerializeField] private MovementConfig _movementConfig;
        public override void InstallBindings()
        {
            Container.Bind<MovementModel>().FromMethod(() => _movementConfig.ToModel()).AsSingle().NonLazy();
            Container.Bind<MovementState>().AsSingle().NonLazy();
            Container.Bind<MoveUsecase>().AsSingle().NonLazy();
            Container.Bind<ToggleStealthModeUsecase>().AsSingle().NonLazy();
            Container.Bind<MovementSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MovementAdapter>().FromInstance(_movementAdapter).AsSingle();
        }
    }
}