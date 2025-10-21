using _Root.CleanCode.HealthFeature.Application;
using _Root.CleanCode.HealthFeature.Domain;
using UnityEngine;
using Zenject;

namespace _Root.CleanCode.HealthFeature.Infrastructure
{
    [RequireComponent(typeof(HealthAdapter))]
    public class HealthInstaller : MonoInstaller
    {
        [SerializeField] private HealthAdapter _healthAdapter;
        [SerializeField] private HealthConfig _healthConfig;
        public override void InstallBindings()
        {
            
            Container.Bind<HealthModel>().FromMethod(() => _healthConfig.ToModel()).AsSingle();
            Container.Bind<HealthState>().AsSingle().NonLazy();
            Container.Bind<GetDamageUseCase>().AsSingle().NonLazy();
            Container.Bind<GetHealUseCase>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<HealthAdapter>().FromInstance(_healthAdapter).AsSingle();
        }
    }
}