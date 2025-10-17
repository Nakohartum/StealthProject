using System;
using Cysharp.Threading.Tasks;

namespace _Root.CleanCode.Shared.Ports.Dialog
{
    public interface IDialogPort
    {
        void StartDialog(string name);
        void AddOnDialogStarted(Action<string> OnDialogStarted);
        void AddOnDialogClosed(Action<string> OnDialogClosed);
    }
}