using _Root.Code.UI;
using UnityEngine;
using UnityEngine.UI;

namespace _Root.Code.CutsceneFeature.Model
{
    [CreateAssetMenu(fileName = nameof(CutscenePartSO), menuName = "Create/Cutscene/"+nameof(CutscenePartSO), order = 0)]
    public class CutscenePartSO : ScriptableObject
    {
        [field: SerializeField] public Image CutsceneBackgroundImage { get; private set; }
        [field: SerializeField] public DialogSO Dialog { get; private set; }
    }
}