using _Root.CleanCode.MovementFeature.Domain;
using UnityEngine;

namespace _Root.CleanCode.MovementFeature.Infrastructure
{
    [CreateAssetMenu(fileName = nameof(MovementConfig), menuName = "Create/Movement/MovementConfig", order = 0)]
    public class MovementConfig : ScriptableObject
    {
        [Tooltip("Movement speed while not in the stealth mode")]
        public float MaxSpeed;
        [Tooltip("Movement speed while in the stealth mode")]
        public float SpeedInStealthMode;
        public float Acceleration;
        public float Deceleration;

        public MovementModel ToModel()
        {
            return new MovementModel(MaxSpeed, Acceleration, Deceleration, SpeedInStealthMode);
        }
    }
}