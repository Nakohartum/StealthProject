using UnityEngine;

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
        }

        private void PerformMove(Vector2 movement)
        {
            Vector2 oldPosition = _rigidbody.transform.position;
            var currentPosition = movement * _speed;
            currentPosition = Vector2.MoveTowards(currentPosition, Vector2.zero, 0);
            _rigidbody.MovePosition(oldPosition+currentPosition);
        }
    }
}