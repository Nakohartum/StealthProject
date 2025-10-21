using _Root.CleanCode.InteractableFeature.Application;
using _Root.CleanCode.Shared.Ports;
using _Root.CleanCode.Shared.Ports.InteractableObject;
using UnityEngine;
using Zenject;

namespace _Root.CleanCode.InteractableFeature.Infrastructure
{
    public class InteractableObject : MonoBehaviour, IInteractablePort
    {
        [SerializeField] private OutlineFx.OutlineFx _outline;
        private InteractionUseCase _interactionUseCase;
        private ToggleInteractionStyleUseCase _interactionStyleUseCase;

        [Inject]
        private void Construct(InteractionUseCase interactionUseCase,  ToggleInteractionStyleUseCase interactionStyleUseCase)
        {
            _interactionUseCase = interactionUseCase;
            _interactionStyleUseCase = interactionStyleUseCase;
        }

        public Vec2 Position => new Vec2(transform.position.x, transform.position.y);

        public void SetHighlighted(bool highlighted)
        {
            _outline.enabled = _interactionStyleUseCase.SetInteractionStyle(highlighted);
        }

        public void Interact()
        {
            _interactionUseCase.Interact();
        }
    }
}