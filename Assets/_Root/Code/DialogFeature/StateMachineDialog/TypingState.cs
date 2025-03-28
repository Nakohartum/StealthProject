using _Root.Code.DialogFeature.Presenter;
using _Root.Code.DialogFeature.View;

namespace _Root.Code.DialogFeature.StateMachineDialog
{
    public class TypingState : IDialogState
    {
        private DialogPresenter _dialogPresenter;
        private DialogView _dialogView;

        public TypingState(DialogPresenter dialogPresenter, DialogView dialogView)
        {
            _dialogPresenter = dialogPresenter;
            _dialogView = dialogView;
        }
        public void Enter()
        {
            var part = _dialogPresenter.CurrentDialogPart;
            _dialogView.ShowDialog(part.CharacterName, part.DialogString, part.CharacterIcon, OnTypingComplete);
        }

        private void OnTypingComplete()
        {
            _dialogPresenter.DialogStateMachine.ChangeState(DialogState.Blinking);
        }

        public void Exit()
        {
            
        }

        public void OnInput()
        {
            _dialogView.StopShowingDialog();
            _dialogView.ShowLine(_dialogPresenter.CurrentDialogPart.DialogString);
            _dialogPresenter.DialogStateMachine.ChangeState(DialogState.Blinking);
        }
    }
}