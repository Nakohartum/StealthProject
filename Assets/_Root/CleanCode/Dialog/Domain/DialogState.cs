using System;

namespace _Root.CleanCode.Dialog.Domain
{
    public class DialogState
    {
        public bool IsPlaying;
        public int CurrentPartsIndex;
        public bool IsTyping;
        public DialogModel CurrentDialog;

        public void ResetState(string _)
        {
            IsPlaying = false;
            CurrentPartsIndex = 0;
            IsTyping = false;
            CurrentDialog = null;
        }
    }
}