using _Root.Code.DialogFeature.Presenter;
using _Root.Code.DialogFeature.View;

namespace _Root.Code.DialogFeature.StateMachineDialog
{
    public class DoneState : IDialogState
    {
        private DialogView _dialogView;
        private DialogPresenter _dialogPresenter;

        public DoneState(DialogView dialogView, DialogPresenter dialogPresenter)
        {
            _dialogView = dialogView;
            _dialogPresenter = dialogPresenter;
        }
        public void Enter()
        {
            _dialogPresenter.CloseDialog();
        }

        public void Exit()
        {
        }

        public void OnInput()
        {
        }
    }
}