using _Root.Code.Health;
using UnityEngine;

namespace GameOne.Player
{
    [CreateAssetMenu(fileName = nameof(PlayerSO), menuName = "Create/Player/"+nameof(PlayerSO), order = 0)]
    public class PlayerSO : ScriptableObject
    {
        [field: SerializeField] public PlayerView PlayerPrefab { get; private set; }
        [field: SerializeField] public float PlayerSpeed { get; private set; }
        [field: SerializeField] public HealthSO HealthSO { get; private set; }
    }
}