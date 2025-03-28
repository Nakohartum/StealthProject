using System;
using _Root.Code.InteractiveObjects;
using _Root.Code.Miscellanious;
using UnityEngine;

namespace _Root.Code.QuestFeature.View
{
    public class PickupItem : InteractableObject
    {
        [SerializeField] private string _pickupItemId;
        [SerializeField] private bool _shouldDestroyOnPickup;


        public override void Interact()
        {
            
            base.Interact();
            EventBus.InvokeItemPickedUp(_pickupItemId);
            if (_shouldDestroyOnPickup)
            {
                Destroy(gameObject);
            }
        }
    }
}