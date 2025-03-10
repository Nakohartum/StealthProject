using UnityEngine;

namespace _Root.Code.CutsceneFeature.Model
{
    [CreateAssetMenu(fileName = nameof(CutsceneSO), menuName = "Create/Cutscene/"+nameof(CutsceneSO), order = 0)]
    public class CutsceneSO : ScriptableObject
    {
        [field: SerializeField] public CutscenePartSO[] CutsceneParts { get; private set; }
    }
}