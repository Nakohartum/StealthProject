using System;

namespace _Root.CleanCode.Shared.Ports.Input
{
    public interface IInputPort
    {
        event Action OnDialogSkipPressed;
        void EnableInput(string inputName);
        void DisableInput(string inputName);
        Vec2 MoveInput { get; }
        bool ToggleStealthMode { get; }
        event Action OnInteractionPressed;
    }
}