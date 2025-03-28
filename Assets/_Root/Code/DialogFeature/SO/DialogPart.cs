using UnityEngine;

namespace _Root.Code.DialogFeature.SO
{
    [CreateAssetMenu(fileName = "DialogPart", menuName = "Create/Dialog/DialogPart", order = 0)]
    public class DialogPart : ScriptableObject
    {
        public string CharacterName;
        public string DialogString;
        public Sprite CharacterIcon;
    }
}