using System.Collections.Generic;
using _Root.CleanCode.Player.Application;
using _Root.CleanCode.Player.Application.Ports;
using _Root.CleanCode.Shared.Ports;
using _Root.CleanCode.Shared.Ports.InteractableObject;
using UnityEngine;
using Zenject;

namespace _Root.CleanCode.InteractableFeature.Infrastructure
{
    public class PhysicsCheckerAdapter : MonoBehaviour, IPhysicsCheckerPort, ITickable
    {
        [SerializeField] private LayerMask _layerMask;
        private InteractiveObjectsCheckerSystem _system;

        [Inject]
        private void Construct(InteractiveObjectsCheckerSystem system)
        {
            _system = system;
        }
        public IReadOnlyList<IInteractablePort> OverlapCircle(Vec2 position, float radius)
        {
            var results = Physics2D.OverlapCircleAll(new Vector2(position.X, position.Y), radius, _layerMask);
            var list = new List<IInteractablePort>(results.Length);
            foreach (var col in results)
            {
                if (col.TryGetComponent<IInteractablePort>(out var h))
                    list.Add(h);
            }
            return list;
        }

        public void Tick()
        {
            _system.Tick();
        }
    }
}