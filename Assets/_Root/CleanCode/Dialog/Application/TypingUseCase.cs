using System.Text;
using _Root.CleanCode.Dialog.Application.Ports;
using _Root.CleanCode.Dialog.Domain;
using _Root.CleanCode.Shared.Ports.Input;
using Cysharp.Threading.Tasks;

namespace _Root.CleanCode.Dialog.Application
{
    public class TypingUseCase
    {
        private IDialogView _dialogView;
        private IInputPort _inputPort;
        private DialogState _dialogState;

        public TypingUseCase(IDialogView dialogView, IInputPort inputPort, DialogState dialogState)
        {
            _dialogView = dialogView;
            _inputPort = inputPort;
            _dialogState = dialogState;
        }

        private void RequestedToSkip()
        {
            _dialogState.IsTyping = false;
        }

        public async UniTask TypeLine(string line)
        {
            _inputPort.OnDialogSkipPressed += RequestedToSkip;
            var sb = new StringBuilder();
            _dialogState.IsTyping = true;
            foreach (var c in line)
            {
                if (!_dialogState.IsTyping)
                {
                    break;
                }
                sb.Append(c);
                _dialogView.ShowLine(sb.ToString());
                await UniTask.Delay(200);
            }
            _dialogView.ShowLine(line);
            _dialogState.IsTyping = false;
            _inputPort.OnDialogSkipPressed -= RequestedToSkip;
        }

        
    }
}