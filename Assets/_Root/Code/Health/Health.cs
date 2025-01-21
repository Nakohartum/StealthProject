using UniRx;
using UnityEngine;

namespace _Root.Code.Health
{
    public class Health
    {
        public float MaxHealth { get; }
        public ReactiveProperty<float> CurrentHealth { get; } = new ReactiveProperty<float>();

        public Health(float maxHealth, float currentHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth.Value = currentHealth;
        }

        public void MinusHealth(float value)
        {
            var currentHealth = CurrentHealth.Value;
            currentHealth = Mathf.Max(currentHealth - value, 0);
            CurrentHealth.Value = currentHealth;
        }

        public void PlusHealth(float value)
        {
            var currentHealth = CurrentHealth.Value;
            currentHealth = Mathf.Min(currentHealth + value, MaxHealth);
            CurrentHealth.Value = currentHealth;
        }
    }
}