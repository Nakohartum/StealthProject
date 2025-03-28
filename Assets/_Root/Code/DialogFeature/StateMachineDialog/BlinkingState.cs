using _Root.Code.DialogFeature.Presenter;
using _Root.Code.DialogFeature.View;

namespace _Root.Code.DialogFeature.StateMachineDialog
{
    public class BlinkingState : IDialogState
    {
        private DialogView _dialogView;
        private DialogPresenter _dialogPresenter;

        public BlinkingState(DialogView dialogView, DialogPresenter dialogPresenter)
        {
            _dialogView = dialogView;
            _dialogPresenter = dialogPresenter;
        }
        
        public void Enter()
        {
            _dialogView.StartBlinkLabel();
        }

        public void Exit()
        {
            
        }

        public void OnInput()
        {
            _dialogView.StopBlinking();
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