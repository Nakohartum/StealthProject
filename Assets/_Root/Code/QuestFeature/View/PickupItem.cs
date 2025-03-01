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

        private void Start()
        {
            _outlineObject.enabled = false;
        }

        public void PickUp()
        {
            EventBus.InvokeItemPickedUp(_pickupItemId);
            Destroy(gameObject);
        }
        
        public void SetInteractionStyleOn()
        {
            if (this.enabled)
            {
                InteractionToggled = true;
                _outlineObject.enabled = true;
            }
        }

        public void SetInteractionStyleOff()
        {
            InteractionToggled = false;
            _outlineObject.enabled = false;
        }
    }
}