using _Root.Code.Health;

namespace GameOne.Player
{
    public class PlayerModel
    {
        public float Speed {get; set;}
        public Health Health {get; set;}

        public PlayerModel(float speed, Health health)
        {
            Speed = speed;
            Health = health;
        }
    }
}