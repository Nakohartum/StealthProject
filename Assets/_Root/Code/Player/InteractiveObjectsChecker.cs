using System.Collections.Generic;
using _Root.Code.Input;
using _Root.Code.InteractiveObjects;
using UnityEngine;
using Zenject;

namespace GameOne.Player
{
    public class InteractiveObjectsChecker : ITickable
    {
        private IInteractable _closestInteractable;
        private IInteractable _previousInteractable;
        private readonly Rigidbody2D _rigidbody;
        private readonly float _radiusOfChecking;
        private InputController _inputController;

        public InteractiveObjectsChecker(Rigidbody2D rigidbody, float radiusOfChecking, InputController inputController)
        {
            _rigidbody = rigidbody;
            _radiusOfChecking = radiusOfChecking;
            _inputController = inputController;
            _inputController.OnInteract += TryToInteract;
        }
        public void Tick()
        {
            var colliders = Physics2D.OverlapCircleAll(_rigidbody.position, _radiusOfChecking);
            if ((_previousInteractable != _closestInteractable) || _previousInteractable == null)
            {
                _previousInteractable = _closestInteractable;
            }
            _closestInteractable = GetClosestInteractable(colliders);
            
            CheckToggleStatus();
        }

        private void TryToInteract()
        {
            if (_closestInteractable != null)
            {
                _closestInteractable.Interact();
            }
        }

        private void CheckToggleStatus()
        {
            if (_closestInteractable != null && Vector2.Distance(_closestInteractable.gameObject.transform.position, _rigidbody.position) < _radiusOfChecking)
            {
                if (!_closestInteractable.InteractionToggled)
                {
                    _closestInteractable.SetInteractionStyleOn();
                }
            }
            

            if (_previousInteractable != null)
            {
                if (Vector2.Distance(_previousInteractable.gameObject.transform.position, _rigidbody.position) > _radiusOfChecking
                    || _previousInteractable != _closestInteractable)
                {
                    _previousInteractable.SetInteractionStyleOff();
                }
            }
        }

        private IInteractable GetClosestInteractable(Collider2D[] colliders)
        {
            IInteractable closestInteractable;
            List<IInteractable> interactables = GetAllInteractables(colliders);
            closestInteractable = interactables.Count > 0 ? interactables[0] : null;
            for (int i = 1; i < interactables.Count; i++)
            {
                var distanceBetweenClosestAndPosition =
                    Vector3.Distance(closestInteractable.gameObject.transform.position, _rigidbody.position);
                var distanceBetweenNextAndPosition =
                    Vector3.Distance(interactables[i].gameObject.transform.position, _rigidbody.position);
                if (distanceBetweenClosestAndPosition > distanceBetweenNextAndPosition)
                {
                    closestInteractable = interactables[i];
                }
            }
            return closestInteractable;
        }

        private List<IInteractable> GetAllInteractables(Collider2D[] colliders)
        {
            List<IInteractable> interactables = new List<IInteractable>();
            foreach (var colliderForChecking in colliders)
            {
                if (colliderForChecking.TryGetComponent(out IInteractable interactable))
                {
                    interactables.Add(interactable);
                }
            }
            return interactables;
        }
    }
}