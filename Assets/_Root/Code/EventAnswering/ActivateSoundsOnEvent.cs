using System;
using _Root.Code.InteractiveObjects;
using _Root.Code.Miscellanious;
using UnityEngine;
using EventType = _Root.Code.Miscellanious.EventType;

namespace _Root.Code.EventAnswering
{
    public class ActivateSoundsOnEvent : MonoBehaviour
    {
        [SerializeField] private InteractableObject _interactableObject;
        [SerializeField] private EventType _eventType;

        private void Start()
        {
            EventBus.AddSubscriber(_eventType, ActivateSound);
        }

        private void ActivateSound()
        {
            _interactableObject.StartMusic();
        }

        private void OnDestroy()
        {
            EventBus.RemoveSubscriber(_eventType, ActivateSound);
        }
    }
}