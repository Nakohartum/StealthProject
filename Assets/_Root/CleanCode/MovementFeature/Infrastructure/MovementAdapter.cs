using _Root.CleanCode.MovementFeature.Application;
using _Root.CleanCode.MovementFeature.Domain;
using _Root.CleanCode.Shared.Ports;
using _Root.CleanCode.Shared.Ports.Move;
using UnityEngine;
using Zenject;

namespace _Root.CleanCode.MovementFeature.Infrastructure
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
    public class MovementAdapter : MonoBehaviour, IMovePort, ITickable, IFixedTickable
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        private MovementState _movementState;
        private MovementSystem _movementSystem;

        [Inject]
        public void Construct(MovementState movementState, MovementSystem movementSystem)
        {
            _movementState = movementState;
            _movementSystem = movementSystem;
        }
        
        public void Move(Vec2 direction)
        {
            const float InputEps  = 0.0001f;
            const float SpeedEps  = 0.01f;

            // was: normalized blindly; now guard zero to avoid NaN
            var input = new Vector2(direction.X, direction.Y);
            var dir   = (input.sqrMagnitude > InputEps) ? input.normalized : Vector2.zero;

            // IMPORTANT small change:
            // CurrentMovementSpeed is a RATE (accel/decel), MaxSpeed is the cap.
            float maxSpeed = Mathf.Max(0f, _movementState.MaxSpeed);
            var desired    = dir * maxSpeed;

            var current    = _rigidbody2D.velocity;
            var delta      = desired - current;

            // clamp Δv by rate * fixedDeltaTime (gives accel/decel)
            float ratePerSec   = Mathf.Max(0f, _movementState.CurrentMovementSpeed);
            float maxDeltaStep = ratePerSec * Time.fixedDeltaTime;
            var appliedDelta   = Vector2.ClampMagnitude(delta, maxDeltaStep);

            if (appliedDelta.sqrMagnitude > InputEps)
            {
                appliedDelta *= _rigidbody2D.mass;
                _rigidbody2D.AddForce(appliedDelta, ForceMode2D.Impulse);
            }

            // was: direct equality check → now sqrMagnitude to avoid jitter
            _movementState.IsMoving = _rigidbody2D.velocity.sqrMagnitude > SpeedEps;
        }

        public void Rotate(Vec2 obj)
        {
            float angle = Vector2.SignedAngle(transform.up, new Vector2(obj.X,  obj.Y));
            transform.Rotate(0,0,angle);
        }

        public void Tick()
        {
            _movementSystem.Tick();
        }

        public void FixedTick()
        {
            _movementSystem.FixedTick();
        }
    }
}