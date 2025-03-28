namespace _Root.Code.DialogFeature.StateMachineDialog
{
    public interface IDialogState
    {
        void Enter();
        void Exit();
        void OnInput();
    }
}