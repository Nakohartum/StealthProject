using UnityEngine;

namespace _Root.Code.Health
{
    [CreateAssetMenu(fileName = nameof(HealthSO), menuName = "Create/Health/"+nameof(HealthSO), order = 0)]
    public class HealthSO : ScriptableObject
    {
        [field: SerializeField] public float MaxHeatlh { get; private set; }
    }
}