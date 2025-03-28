using UnityEngine;

namespace _Root.Code.DialogFeature.SO
{
    [CreateAssetMenu(fileName = "Dialog", menuName = "Create/Dialog/Dialog", order = 0)]
    public class Dialog : ScriptableObject
    {
        public DialogPart[] Parts;
    }
}