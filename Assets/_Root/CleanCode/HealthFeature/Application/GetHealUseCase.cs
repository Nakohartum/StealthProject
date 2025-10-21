using System;
using _Root.CleanCode.HealthFeature.Domain;

namespace _Root.CleanCode.HealthFeature.Application
{
    public class GetHealUseCase
    {
        private HealthState _healthState;
        private HealthModel _healthModel;

        public GetHealUseCase(HealthState healthState, HealthModel healthModel)
        {
            _healthState = healthState;
            _healthModel = healthModel;
        }

        public void ApplyHealth(float heal)
        {
            _healthState.CurrentHealth = Math.Min(_healthModel.MaxHealth, _healthState.CurrentHealth + heal);
        }
    }
}