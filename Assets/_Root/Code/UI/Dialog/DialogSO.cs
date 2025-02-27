using System.Collections.Generic;
using UnityEngine;

namespace _Root.Code.UI
{
    [CreateAssetMenu(fileName = nameof(DialogSO), menuName = "Create/Dialog/"+nameof(DialogSO), order = 0)]
    public class DialogSO : ScriptableObject
    {
        [field: SerializeField] public List<EditorHelpers.KeyValuePair<string, EditorHelpers.KeyValuePair<string, Sprite>>> TextToShow { get; private set; }
    }
}