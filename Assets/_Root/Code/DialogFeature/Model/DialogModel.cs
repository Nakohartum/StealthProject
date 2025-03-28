using _Root.Code.DialogFeature.SO;
using UnityEngine;

namespace _Root.Code.DialogFeature.Model
{
    public class DialogModel
    {
        public Dialog Dialog { get; set; }
        private int _currentDialogPart = 0;

        public DialogModel(Dialog dialog)
        {
            Dialog = dialog;
        }

        public DialogPart GetCurrentDialogPart()
        {
            if (_currentDialogPart < Dialog.Parts.Length)
            {
                return Dialog.Parts[_currentDialogPart];
            }
            return null;
        }

        public bool DialogPartsLeft()
        {
            _currentDialogPart++;
            return _currentDialogPart < Dialog.Parts.Length;
        }
    }
}