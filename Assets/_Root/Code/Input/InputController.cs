using System;
using _Root.Code.InteractiveObjects;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _Root.Code.Input
{
    public class InputController : ITickable
    {
        private InputActions _inputActions;
        public event Action<Vector2> OnMove = v => { };
        [Inject(Id = "deltaTime")] private float _deltaTime;
        public event Action OnAnyKeyEntered = () => { };
        public event Action OnInteract = () => { };

        public InputController(InputActions inputActions)
        {
            _inputActions = inputActions;
            EnablePlayerInput();
            DisableAnyKey();
        }

        public void EnablePlayerInput()
        {
            _inputActions.PlayerMovement.Enable();
            if (_inputActions.PlayerMovement.enabled)
            {
                _inputActions.PlayerMovement.Interact.performed += InteractOnperformed;
            }
            EnableAnyKey();
        }

        public void Tick()
        {
            ReadMovementValue();
        }


        private void InteractOnperformed(InputAction.CallbackContext obj)
        {
            OnInteract();
            _inputActions.PlayerMovement.AnyKey.Enable();
        }

        private void ReadMovementValue()
        {
            if (_inputActions.PlayerMovement.Move.enabled)
            {
                var movementVector = _inputActions.PlayerMovement.Move.ReadValue<Vector2>();
                OnMove(movementVector * _deltaTime);
            }
        }

        public void DisableAnyKey()
        {
            _inputActions.PlayerMovement.AnyKey.Disable();
        }
        
        public void EnableAnyKey()
        {
            _inputActions.PlayerMovement.AnyKey.Enable();
        }

        public bool AnyKeyPressed()
        {
            return _inputActions.PlayerMovement.AnyKey.triggered;
        }

        public void DisablePlayerMove()
        {
            _inputActions.PlayerMovement.Move.Disable();
        }

        public void EnablePlayerMove()
        {
            _inputActions.PlayerMovement.Move.Enable();
        }
    }
}