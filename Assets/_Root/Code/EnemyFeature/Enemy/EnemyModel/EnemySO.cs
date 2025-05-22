using _Root.Code.Health;
using UnityEngine;

namespace _Root.Code.EnemyFeature.Enemy.EnemyModel
{
    [CreateAssetMenu(fileName = nameof(EnemySO), menuName = "Create/Enemy", order = 0)]
    public class EnemySO : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }
        [field: SerializeField] public HealthSO Health { get; private set; }
        [field: SerializeField] public float ViewRadius { get; private set; }
        [field: SerializeField] public float ViewAngle{ get; private set; }
        [field: SerializeField] public LayerMask PlayerMask { get; private set; }
        [field: SerializeField] public LayerMask ObstacleMask { get; private set; }
    }
}