using System;
using System.Collections;
using System.Collections.Generic;
using _Root.Code.InteractiveObjects.InteractionStrategy;
using UnityEngine;
using Zenject;

namespace _Root.Code.InteractiveObjects
{
    public class InteractableObject : MonoBehaviour, IInteractable
    {
        private OutlineFx.OutlineFx _outlineObject;
        private List<IInteractionStrategy> _interactionStrategies = new();
        public bool InteractionToggled { get; private set; }
        public void Initialize(OutlineFx.OutlineFx outlineFx, IInteractionStrategy[] strategies)
        {
            _outlineObject = outlineFx;
            _interactionStrategies.AddRange(strategies);
            _outlineObject.enabled = false;
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

        public virtual void Interact()
        {
            foreach (var strategy in _interactionStrategies)
            {
                strategy.Interact();
            }
        }

        public void StartMusic()
        {
            var audioStrategy = _interactionStrategies.Find(q => q is PlaySoundsStrategy);
            audioStrategy?.Interact();
        }
    }
}