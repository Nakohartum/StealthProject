using _Root.Code.Health;
using UnityEngine;

namespace GameOne.Player
{
    public class PlayerModel
    {
        public AudioClip[] StepSounds { get; set; }
        public float Speed {get; set;}
        public Health Health {get; set;}

        public PlayerModel(float speed, Health health, AudioClip[] stepSounds)
        {
            Speed = speed;
            Health = health;
            StepSounds = stepSounds;
        }
    }
}