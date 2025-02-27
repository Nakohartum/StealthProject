using System;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace _Root.Code.Miscellanious
{
    public static class EventBus
    {
        private static Dictionary<EventType, Action> _events = new Dictionary<EventType, Action>();
        public static event Action<string> OnLocationAchieved = delegate { }; 
        public static event Action<string> OnItemPickedUp = delegate { };

        public static void AddSubscriber(EventType eventName, Action subscriber)
        {
            if (!_events.TryAdd(eventName, subscriber))
            {
                _events[eventName] += subscriber;
            }
        }

        public static void RemoveSubscriber(EventType eventName, Action subscriber)
        {
            if (_events.ContainsKey(eventName))
            {
                _events[eventName] -= subscriber;
            }
        }

        public static void InvokeLocationAchieved(string location)
        {
            OnLocationAchieved(location);
        }

        public static void InvokeItemPickedUp(string item)
        {
            OnItemPickedUp(item);
        }

        public static void Invoke(EventType eventName)
        {
            if (_events.ContainsKey(eventName))
            {
                _events[eventName]?.Invoke();
            }
        }
    }
}