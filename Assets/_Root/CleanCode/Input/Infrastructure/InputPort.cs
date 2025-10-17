using System;
using _Root.CleanCode.Shared.Ports;
using _Root.CleanCode.Shared.Ports.Input;
using Shared._Root.CleanCode.Shared.Helper;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Root.CleanCode.Input.Infrastructure
{
    public class InputPort : IInputPort
    {
        private InputActions _playerInput;
        private InputActions.PlayerMovementActions _playerKeys;
        private InputActions.DialogInputActions _dialogKeys;
        
        public Vec2 MoveInput
        {
            get
            {
                var vector2 = _playerKeys.Move.ReadValue<Vector2>();
                return new Vec2(vector2.x, vector2.y);
            }
        }

        public bool ToggleStealthMode => _playerKeys.ToggleStealth.WasPressedThisFrame();
        public event Action OnInteractionPressed;

        public InputPort()
        {
            _playerInput = new InputActions();
            _playerKeys = _playerInput.PlayerMovement;
            _dialogKeys = _playerInput.DialogInput;
            _dialogKeys.Skip.performed += OnDialogSkipPerfomed;
            _playerKeys.Interact.performed += OnInteractionPerfomed;
            EnableInput(Strings.InputStrings.PlayerInput);
        }

        private void OnInteractionPerfomed(InputAction.CallbackContext obj)
        {
            OnInteractionPressed?.Invoke();
        }

        private void OnDialogSkipPerfomed(InputAction.CallbackContext obj)
        {
            OnDialogSkipPressed?.Invoke();
        }

        public event Action OnDialogSkipPressed;

        public void EnableInput(string inputName)
        {
            DisableAllInputs();
            switch (inputName)
            {
                case Strings.InputStrings.PlayerInput:
                    _playerKeys.Enable();
                    break;
                case  Strings.InputStrings.DialogInput:
                    _dialogKeys.Enable();
                    break;
            }
        }

        private void DisableAllInputs()
        {
            _playerKeys.Disable();
            _dialogKeys.Disable();
        }

        public void DisableInput(string inputName)
        {
            switch (inputName)
            {
                case Strings.InputStrings.PlayerInput:
                    _playerKeys.Disable();
                    break;
            }
        }

        
    }
}