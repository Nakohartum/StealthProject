using System;
using _Root.CleanCode.HealthFeature.Domain;

namespace _Root.CleanCode.HealthFeature.Application
{
    public class GetDamageUseCase
    {
        private HealthState _healthState;
        private HealthModel _healthModel;
        
        public GetDamageUseCase(HealthState healthState, HealthModel healthModel)
        {
            _healthState = healthState;
            _healthModel = healthModel;
        }

        public void GetDamage(float damage)
        {
            _healthState.CurrentHealth = Math.Max(0, _healthState.CurrentHealth - damage);
        }
    }
}