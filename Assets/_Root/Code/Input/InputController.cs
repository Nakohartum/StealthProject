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
        private float _deltaTime;
        public event Action OnAnyKeyEntered = () => { };
        public event Action OnInteract = () => { };

        [Inject]
        public InputController(float deltaTime)
        {
            _inputActions = new InputActions();
            _deltaTime = deltaTime;
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
            if (_inputActions.PlayerMovement.AnyKey.enabled)
            {
                _inputActions.PlayerMovement.AnyKey.performed += OnAnyKeyPressed;
            }
        }

        private void OnAnyKeyPressed(InputAction.CallbackContext obj)
        {
            OnAnyKeyEntered();
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

        public void DisableInteractionKey()
        {
            _inputActions.PlayerMovement.Interact.Disable();
        }
        
        public void EnableInteractionKey()
        {
            _inputActions.PlayerMovement.Interact.Enable();
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
            return _inputActions.PlayerMovement.AnyKey.IsPressed();
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