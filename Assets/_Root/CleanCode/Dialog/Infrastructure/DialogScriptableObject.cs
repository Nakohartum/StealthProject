using UnityEngine;

namespace _Root.CleanCode.Dialog.Infrastructure
{
    [CreateAssetMenu(fileName = nameof(DialogScriptableObject), menuName = "Create/Dialog/Dialog")]
    public class DialogScriptableObject : ScriptableObject
    {
        public string DialogId;
        public DialogPartScriptableObject[] Parts;
        public bool IsInteractable;
    }
}