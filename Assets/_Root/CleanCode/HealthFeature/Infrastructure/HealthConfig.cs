using _Root.CleanCode.HealthFeature.Domain;
using UnityEngine;

namespace _Root.CleanCode.HealthFeature.Infrastructure
{
    [CreateAssetMenu(fileName = nameof(HealthConfig), menuName = "Create/Health/Health", order = 0)]
    public class HealthConfig : ScriptableObject
    {
        [SerializeField] private float _maxHealth;

        public HealthModel ToModel()
        {
            return new HealthModel
            {
                MaxHealth = _maxHealth
            };
        }
    }
}