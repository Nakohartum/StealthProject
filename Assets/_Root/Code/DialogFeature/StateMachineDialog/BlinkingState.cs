using System;
using System.Threading;
using _Root.Code.DialogFeature.Presenter;
using _Root.Code.DialogFeature.View;
using Cysharp.Threading.Tasks;

namespace _Root.Code.DialogFeature.StateMachineDialog
{
    public class BlinkingState : IDialogState
    {
        private DialogView _dialogView;
        private DialogPresenter _dialogPresenter;
        private CancellationTokenSource _cts;

        public BlinkingState(DialogView dialogView, DialogPresenter dialogPresenter)
        {
            _dialogView = dialogView;
            _dialogPresenter = dialogPresenter;
        }
        
        public void Enter()
        {
            _cts = new CancellationTokenSource();
            BlinkLoop().Forget();
        }

        private async UniTask BlinkLoop()
        {
            try
            {
                await _dialogView.ShowNextLabelAsync(_cts.Token);
            }
            catch (OperationCanceledException e)
            {
            }
        }

        public void Exit()
        {
            
        }

        public void OnInput()
        {
            _cts?.Cancel();
            if (_dialogPresenter.NextPartAvailable())
            {
                _dialogPresenter.ShowNextPart();
                _dialogPresenter.DialogStateMachine.ChangeState(DialogState.Typing);
            }
            else
            {
                _dialogPresenter.DialogStateMachine.ChangeState(DialogState.Done);
            }
        }
    }
}