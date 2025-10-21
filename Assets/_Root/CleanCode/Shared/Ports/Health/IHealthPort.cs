using System;

namespace _Root.CleanCode.Shared.Ports.Health
{
    public interface IHealthPort
    {
        void AddHealth(float value);
        void RemoveHealth(float value);
        Action<float> OnHealthChange { get; }
        Action OnDeath { get; }
    }
}