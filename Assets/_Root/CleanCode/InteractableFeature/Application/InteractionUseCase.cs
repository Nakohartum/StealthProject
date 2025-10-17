using _Root.CleanCode.InteractableFeature.Application.Ports;

namespace _Root.CleanCode.InteractableFeature.Application
{
    public class InteractionUseCase
    {
        private IInteractionStrategy [] _strategies;

        public InteractionUseCase(IInteractionStrategy[] strategies)
        {
            _strategies = strategies;
        }

        public void Interact()
        {
            foreach (var strategy in _strategies)
            {
                strategy.Interact();
            }
        }
    }
}