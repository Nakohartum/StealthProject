using System;
using UnityEngine;

namespace _Root.Code.InteractiveObjects
{
    public interface IInteractable
    {
        GameObject gameObject { get; }
        bool InteractionToggled { get; }
        void SetInteractionStyleOn();
        void SetInteractionStyleOff();
        void Interact();
        event Action OnInteractionDone;
    }
}