using _Root.Code.Health;
using UnityEngine;

namespace _Root.Code.EnemyFeature.Enemy.EnemyModel
{
    [CreateAssetMenu(fileName = nameof(EnemySO), menuName = "Create/Enemy", order = 0)]
    public class EnemySO : ScriptableObject
    {
        [field: SerializeField] public EnemyModel Model { get; private set; }
        [field: SerializeField] public HealthSO Health { get; private set; }
    }
}