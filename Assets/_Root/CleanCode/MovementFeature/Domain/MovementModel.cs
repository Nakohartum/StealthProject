namespace _Root.CleanCode.MovementFeature.Domain
{
    public class MovementModel
    {
        public float MaxSpeed { get; }
        public float Acceleration { get;  }
        public float Deceleration { get;  }
        public float SpeedInStealthMode { get;  }

        public MovementModel(float maxSpeed, float acceleration, float deceleration, float speedInStealthMode)
        {
            MaxSpeed = maxSpeed;
            Acceleration = acceleration;
            Deceleration = deceleration;
            SpeedInStealthMode = speedInStealthMode;
        }
    }
}