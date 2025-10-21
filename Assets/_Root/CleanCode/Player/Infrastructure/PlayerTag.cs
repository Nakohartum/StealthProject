using _Root.CleanCode.Shared.Ports;
using _Root.CleanCode.Shared.Ports.Player;
using UnityEngine;

namespace _Root.CleanCode.Player.Infrastructure
{
    public class PlayerTag : MonoBehaviour, IPlayerTag
    {
        public Vec2 Position => new(transform.position.x, transform.position.y);
    }
}