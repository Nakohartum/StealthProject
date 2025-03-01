using System.Collections.Generic;
using _Root.Code.Input;
using _Root.Code.InteractiveObjects;
using _Root.Code.QuestFeature.View;
using UnityEngine;
using Zenject;

namespace GameOne.Player
{
    public class PickupItemChecker : ITickable
    {
        private PickupItem _closestPickupItem;
        private PickupItem _previousPickupItem;
        private Rigidbody2D _rigidbody;
        private float _checkingRadius;
        private InputController _inputController;

        public PickupItemChecker(Rigidbody2D rigidbody, float checkingRadius, InputController inputController)
        {
            _rigidbody = rigidbody;
            _checkingRadius = checkingRadius;
            _inputController = inputController;
            _inputController.OnInteract += TryToInteract;
        }


        public void Tick()
        {
            var colliders = Physics2D.OverlapCircleAll(_rigidbody.position, _checkingRadius);
            if ((_previousPickupItem != _closestPickupItem) || _previousPickupItem == null)
            {
                _previousPickupItem = _closestPickupItem;
            }
            _closestPickupItem = GetClosestPickup(colliders);
            CheckToggleStatus();
        }
        
        
        private void TryToInteract()
        {
            if (_closestPickupItem != null)
            {
                _closestPickupItem.PickUp();
            }
        }

        private void CheckToggleStatus()
        {
            if (_closestPickupItem != null && Vector2.Distance(_closestPickupItem.gameObject.transform.position, _rigidbody.position) < _checkingRadius)
            {
                if (!_closestPickupItem.InteractionToggled)
                {
                    _closestPickupItem.SetInteractionStyleOn();
                }
            }
            

            if (_previousPickupItem != null)
            {
                if (Vector2.Distance(_previousPickupItem.gameObject.transform.position, _rigidbody.position) > _checkingRadius
                    || _previousPickupItem != _closestPickupItem)
                {
                    _previousPickupItem.SetInteractionStyleOff();
                }
            }
            
        }

        private PickupItem GetClosestPickup(Collider2D[] colliders)
        {
            List<PickupItem> pickupItems = GetAllPickups(colliders);
            var closestPickup = pickupItems.Count > 0 ? pickupItems[0] : null;
            for (int i = 1; i < pickupItems.Count; i++)
            {
                var distanceBetweenClosestAndPosition =
                    Vector3.Distance(closestPickup.gameObject.transform.position, _rigidbody.position);
                var distanceBetweenNextAndPosition =
                    Vector3.Distance(pickupItems[i].gameObject.transform.position, _rigidbody.position);
                if (distanceBetweenClosestAndPosition > distanceBetweenNextAndPosition)
                {
                    closestPickup = pickupItems[i];
                }
            }
            return closestPickup;
        }

        private List<PickupItem> GetAllPickups(Collider2D[] colliders)
        {
            List<PickupItem> pickupItems = new List<PickupItem>();
            foreach (var colliderForChecking in colliders)
            {
                if (colliderForChecking.TryGetComponent(out PickupItem pickupItem))
                {
                    pickupItems.Add(pickupItem);
                }
            }
            return pickupItems;
        }
    }
}