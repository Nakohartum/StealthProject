using System;
using _Root.CleanCode.Shared.Ports.Dialog;

namespace _Root.CleanCode.Dialog.Infrastructure
{
    public class DialogPortProxy : IDialogPort
    {
        private IDialogPort _dialogPort;

        public void SetImplementation(IDialogPort dialogPort)
        {
            _dialogPort = dialogPort;
        }
        
        public void StartDialog(string name)
        {
            _dialogPort.StartDialog(name);
        }

        public void AddOnDialogStarted(Action<string> onDialogStarted)
        {
            _dialogPort.AddOnDialogStarted(onDialogStarted);
        }

        public void AddOnDialogClosed(Action<string> onDialogClosed)
        {
            _dialogPort.AddOnDialogClosed(onDialogClosed);
        }
    }
}