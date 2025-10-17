using System;
using _Root.CleanCode.HealthFeature.Application;
using _Root.CleanCode.HealthFeature.Domain;
using _Root.CleanCode.Shared.Ports.Health;
using UnityEngine;
using Zenject;

namespace _Root.CleanCode.HealthFeature.Infrastructure
{
    public class HealthAdapter : MonoBehaviour, IHealthPort
    {
        private GetDamageUseCase _getDamageUseCase;
        private GetHealUseCase _getHealUseCase;
        private HealthState _healthState;
        public Action<float> OnHealthChange { get; }
        public Action OnDeath { get; }

        [Inject]
        public void Construct(GetDamageUseCase getDamageUseCase, GetHealUseCase getHealUseCase, HealthState healthState)
        {
            _getDamageUseCase = getDamageUseCase;
            _getHealUseCase = getHealUseCase;
            _healthState = healthState;
        }


        public void AddHealth(float value)
        {
            _getHealUseCase.ApplyHealth(value);
            OnHealthChange?.Invoke(_healthState.CurrentHealth);
        }

        public void RemoveHealth(float value)
        {
            _getDamageUseCase.GetDamage(value);
            OnHealthChange?.Invoke(_healthState.CurrentHealth);
            if (_healthState.CurrentHealth == 0)
            {
                OnDeath?.Invoke();
            }
        }
    }
}