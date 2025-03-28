using System.Collections.Generic;

namespace _Root.Code.DialogFeature.StateMachineDialog
{
    public class DialogStateMachine
    {
        private IDialogState _currentDialogState;
        private Dictionary<DialogState, IDialogState> _dialogStates;

        public DialogStateMachine(Dictionary<DialogState, IDialogState> dialogStates)
        {
            _dialogStates = dialogStates;
        }

        public void ChangeState(DialogState newState)
        {
            _currentDialogState?.Exit();
            _currentDialogState = _dialogStates[newState];
            _currentDialogState?.Enter();
        }

        public void HandleInput()
        {
            _currentDialogState?.OnInput();
        }
    }

    public enum DialogState
    {
        Typing,
        Blinking,
        Done
    }
}