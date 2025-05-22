using System;
using UnityEngine;

namespace _Root.Code.EnemyFeature.Enemy.EnemyModel
{
    [Serializable]
    public class EnemyModel
    {
        public Health.Health Health { get; private set; }
        public float Speed { get; private set; }
        public float RotationSpeed { get; private set; }
        public Vector3 Position { get; private set; }

        public EnemyModel(Health.Health health, float speed, float rotationSpeed, Vector3 position)
        {
            Health = health;
            Speed = speed;
            RotationSpeed = rotationSpeed;
            Position = position;
        }

        public void UpdatePosition(Vector3 position)
        {
            Position = position;
        }
    }
}