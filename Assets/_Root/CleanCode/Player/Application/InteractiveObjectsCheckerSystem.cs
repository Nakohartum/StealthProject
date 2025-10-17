
using System;
using _Root.CleanCode.Player.Application.Ports;
using _Root.CleanCode.Shared.Ports.Input;
using _Root.CleanCode.Shared.Ports.InteractableObject;
using _Root.CleanCode.Shared.Ports.Player;

namespace _Root.CleanCode.Player.Application
{
    public class InteractiveObjectsCheckerSystem
    {
        private IPlayerTag _playerTag;
        private IPhysicsCheckerPort _physicsCheckerPort;
        private IInteractablePort _currentInteractable;
        private IInputPort _inputPort;

        public InteractiveObjectsCheckerSystem(IPlayerTag playerTag, IPhysicsCheckerPort physicsCheckerPort, IInputPort inputPort)
        {
            _playerTag = playerTag;
            _physicsCheckerPort = physicsCheckerPort;
            _inputPort = inputPort;
            _inputPort.OnInteractionPressed += InteractionPressed;
        }

        private void InteractionPressed()
        {
            _currentInteractable?.Interact();
        }

        public void Tick()
        {
            var candidates = _physicsCheckerPort.OverlapCircle(_playerTag.Position, 5f);

            if (_currentInteractable != null)
            {
                var distance = (_currentInteractable.Position - _playerTag.Position).SqrMagnitude;

                _currentInteractable.SetHighlighted(Math.Sqrt(distance) < 5f);
            }

            IInteractablePort interactable = null;
            float bestDist = float.MaxValue;
            foreach (var candidate in candidates)
            {
                var dist = (candidate.Position - _playerTag.Position).SqrMagnitude;
                if (dist < bestDist)
                {
                    bestDist = dist;
                    interactable = candidate;
                }
            }

            if (interactable != null && _currentInteractable != null)
            {
                if (_currentInteractable != interactable)
                {
                    _currentInteractable.SetHighlighted(false);
                    _currentInteractable = interactable;
                }
            }
            else if (interactable != null)
            {
                _currentInteractable =  interactable;
            }
            
        }
    }
}