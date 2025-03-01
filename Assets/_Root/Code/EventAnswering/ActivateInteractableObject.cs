using System;
using _Root.Code.InteractiveObjects;
using _Root.Code.Miscellanious;
using UnityEngine;
using EventType = _Root.Code.Miscellanious.EventType;

namespace _Root.Code.EventAnswering
{
    public class ActivateInteractableObject : MonoBehaviour
    {
        [SerializeField] private InteractableObject _interactableObject;
        [SerializeField] private EventType _eventType;

        private void Start()
        {
            EventBus.AddSubscriber(_eventType, ActivateObject);
        }

        private void ActivateObject()
        {
            _interactableObject.enabled = true;
        }

        private void OnDestroy()
        {
            EventBus.RemoveSubscriber(_eventType, ActivateObject);
        }
    }
}