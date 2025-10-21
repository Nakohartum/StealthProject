using _Root.CleanCode.Dialog.Domain;

namespace _Root.CleanCode.Dialog.Application
{
    public class TryProceedToNextLineUseCase
    {
        private DialogState _dialogState;

        public TryProceedToNextLineUseCase(DialogState dialogState)
        {
            _dialogState = dialogState;
        }
        
        public void HasOtherLinesToProceed(DialogModel model)
        {
            if (_dialogState.CurrentPartsIndex >= model.Parts.Length - 1)
            {
                _dialogState.IsPlaying = false;
            }
            else
            {
                _dialogState.IsPlaying = true;
                _dialogState.CurrentPartsIndex++;
            }
        }
    }
}