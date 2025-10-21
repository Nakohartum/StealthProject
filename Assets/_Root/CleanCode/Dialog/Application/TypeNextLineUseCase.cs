using _Root.CleanCode.Dialog.Application.Ports;
using _Root.CleanCode.Dialog.Domain;
using Cysharp.Threading.Tasks;

namespace _Root.CleanCode.Dialog.Application
{
    public class TypeNextLineUseCase
    {
        private DialogState _dialogState;
        private TypingUseCase _typingUseCase;
        private IDialogView _dialogView;
        
        public TypeNextLineUseCase(DialogState dialogState, TypingUseCase typingUseCase, IDialogView dialogView)
        {
            _dialogState = dialogState;
            _typingUseCase = typingUseCase;
            _dialogView = dialogView;
        }

        public async UniTask TypeNextLine()
        {
            _dialogView.ShowAuthor(_dialogState.CurrentDialog.Parts[_dialogState.CurrentPartsIndex].Actor);
            await _dialogView.ShowImage(_dialogState.CurrentDialog.Parts[_dialogState.CurrentPartsIndex].ImagePath);
            await _typingUseCase.TypeLine(_dialogState.CurrentDialog.Parts[_dialogState.CurrentPartsIndex].Phrase);
        }
    }
}