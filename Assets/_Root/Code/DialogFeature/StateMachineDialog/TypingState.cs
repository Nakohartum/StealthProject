using System;
using System.Threading;
using _Root.Code.DialogFeature.Presenter;
using _Root.Code.DialogFeature.View;
using Cysharp.Threading.Tasks;

namespace _Root.Code.DialogFeature.StateMachineDialog
{
    public class TypingState : IDialogState
    {
        private DialogPresenter _dialogPresenter;
        private DialogView _dialogView;
        private CancellationTokenSource _cts;

        public TypingState(DialogPresenter dialogPresenter, DialogView dialogView)
        {
            _dialogPresenter = dialogPresenter;
            _dialogView = dialogView;
        }
        public void Enter()
        {
            _cts = new CancellationTokenSource();
            var part = _dialogPresenter.CurrentDialogPart;
            _dialogView.SetDialogMeta(part.CharacterName, part.CharacterIcon);
            TypeText(part.DialogString).Forget();
        }

        private async UniTaskVoid TypeText(string text)
        {
            try
            {
                await _dialogView.ShowDialogAsync(text, _cts.Token);
                _dialogPresenter.DialogStateMachine.ChangeState(DialogState.Blinking);
            }
            catch (OperationCanceledException e)
            {
                
            }
        }

        public void Exit()
        {
            _cts?.Cancel();
        }

        public void OnInput()
        {
            _cts?.Cancel();
            _dialogView.ShowLine(_dialogPresenter.CurrentDialogPart.DialogString);
            _dialogPresenter.DialogStateMachine.ChangeState(DialogState.Blinking);
        }
    }
}