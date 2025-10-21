using System.Collections.Generic;
using _Root.CleanCode.Shared.Ports;
using _Root.CleanCode.Shared.Ports.InteractableObject;

namespace _Root.CleanCode.Player.Application.Ports
{
    public interface IPhysicsCheckerPort
    {
        IReadOnlyList<IInteractablePort> OverlapCircle(Vec2 position, float radius);
    }
}