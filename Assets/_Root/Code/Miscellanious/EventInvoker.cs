using System;
using UnityEngine;

namespace _Root.Code.Miscellanious
{
    public class EventInvoker : MonoBehaviour
    {
        [SerializeField] private EventType _eventType;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            InvokeEvent();
        }

        public void InvokeEvent()
        {
            EventBus.Invoke(_eventType);
        }
    }
}