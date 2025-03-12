using System;
using _Root.Code.Miscellanious;
using UnityEngine;

namespace _Root.Code.QuestFeature.View
{
    public class PickupItem : MonoBehaviour
    {
        public bool InteractionToggled { get; private set; }
        [SerializeField] private string _pickupItemId;
        [SerializeField] private OutlineFx.OutlineFx _outlineObject;
        [SerializeField] private bool _shouldDestroyOnPickup;

        private void Start()
        {
            if (_outlineObject != null)
            {
                _outlineObject.enabled = false;
            }
        }

        public void PickUp()
        {
            EventBus.InvokeItemPickedUp(_pickupItemId);
            if (_shouldDestroyOnPickup)
            {
                Destroy(gameObject);
            }
        }
        
        public void SetInteractionStyleOn()
        {
            if (this.enabled && _outlineObject != null)
            {
                InteractionToggled = true;
                _outlineObject.enabled = true;
            }
        }

        public void SetInteractionStyleOff()
        {
            InteractionToggled = false;
            if (_outlineObject != null)
            {
                _outlineObject.enabled = false;
            }
        }
    }
}