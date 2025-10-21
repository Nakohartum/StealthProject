namespace _Root.CleanCode.Shared.Ports.InteractableObject
{
    public interface IInteractablePort
    {
        Vec2 Position { get; }
        void SetHighlighted(bool highlighted);
        void Interact();
    }
}