using _Root.CleanCode.Dialog.Application.Ports;
using _Root.CleanCode.Dialog.Domain;
using Cysharp.Threading.Tasks;

namespace _Root.CleanCode.Dialog.Application
{
    public class StartDialogUseCase
    {
        private TypingUseCase _typingUseCase;
        private IDialogView _dialogView;

        public StartDialogUseCase(TypingUseCase typingUseCase, IDialogView dialogView)
        {
            _typingUseCase = typingUseCase;
            _dialogView = dialogView;
        }
        public async UniTask StartDialog(DialogPart firstPart)
        {
            _dialogView.ShowAuthor(firstPart.Actor);
            await _dialogView.ShowImage(firstPart.ImagePath);
            await _typingUseCase.TypeLine(firstPart.Phrase);
        }
    }
}