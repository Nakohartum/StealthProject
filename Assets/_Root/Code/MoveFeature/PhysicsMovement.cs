﻿using UnityEngine;

namespace _Root.Code.MoveFeature
{
    public class PhysicsMovement : IMovable
    {
        private Rigidbody2D _rigidbody;
        private float _speed;

        public PhysicsMovement(Rigidbody2D rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            _speed = speed;
        }

        public void Move(Vector2 movement)
        {
            if (movement.magnitude > 0)
            {
                PerformMove(movement);
            }
            else
            {
                StopMovement();
            }
        }

        private void PerformMove(Vector2 movement)
        {
            Vector2 oldPosition = _rigidbody.transform.position;
            _rigidbody.MovePosition(oldPosition+(movement*_speed));
        }

        private void StopMovement()
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }
}