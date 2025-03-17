using UnityEngine;

namespace _Root.Code.LevelManager
{
    [CreateAssetMenu(fileName = nameof(LevelSO), menuName = "Create/Level/"+nameof(LevelSO), order = 0)]
    public class LevelSO : ScriptableObject
    {
        [field: SerializeField] public string LevelName { get; private set; }
        [field: SerializeField] public Level LevelObject { get; private set; }
        
    }
}