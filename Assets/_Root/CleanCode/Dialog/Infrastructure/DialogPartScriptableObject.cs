using UnityEngine;

namespace _Root.CleanCode.Dialog.Infrastructure
{
    [CreateAssetMenu(fileName = nameof(DialogPartScriptableObject), menuName = "Create/Dialog/Dialog part", order = 0)]
    public class DialogPartScriptableObject : ScriptableObject
    {
        public string Actor;
        public string Phrase;
        public string ImagePath;
    }
}