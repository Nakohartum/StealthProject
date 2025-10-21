namespace _Root.CleanCode.Dialog.Domain
{
    public class DialogModel
    {
        public string DialogId;
        public DialogPart[] Parts;
        public bool IsInteractable;

        public DialogModel(string dialogId, DialogPart[] parts, bool isInteractable)
        {
            DialogId = dialogId;
            Parts = parts;
            IsInteractable = isInteractable;
        }
        
        
    }
}