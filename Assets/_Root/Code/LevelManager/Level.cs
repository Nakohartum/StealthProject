using UnityEngine;

namespace _Root.Code.LevelManager
{
    public class Level : MonoBehaviour
    {
        [field: SerializeField] public AudioClip LevelMusic { get; private set; }
        [field: SerializeField] public Transform PlayerSpawnPosition { get; private set; }
    }
}