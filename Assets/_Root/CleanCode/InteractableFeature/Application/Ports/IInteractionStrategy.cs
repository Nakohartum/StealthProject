using Zenject;

namespace _Root.CleanCode.InteractableFeature.Application.Ports
{
    public interface IInteractionStrategy : IInitializable
    {
        void Interact();
    }
}