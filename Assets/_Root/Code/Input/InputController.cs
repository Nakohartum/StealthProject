using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Root.Code.Input
{
    public class InputController : ITickable
    {
        private InputActions _inputActions;
        public event Action<Vector2> OnMove = v => { };
        [Inject(Id = "deltaTime")] private float _deltaTime;

        public InputController(InputActions inputActions)
        {
            _inputActions = inputActions;
            EnablePlayerMovement();
        }

        public void EnablePlayerMovement()
        {
            _inputActions.PlayerMovement.Enable();
        }

        public void Tick()
        {
            ReadMovementValue();
        }

        private void ReadMovementValue()
        {
            if (_inputActions.PlayerMovement.enabled)
            {
                var movementVector = _inputActions.PlayerMovement.Move.ReadValue<Vector2>();
                OnMove(movementVector * _deltaTime);
            }
        }
    }
}