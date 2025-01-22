using UnityEngine;

namespace _Root.Code.MoveFeature
{
    public class TransformMovement : IMovable
    {
        private Transform _transform;
        private float _speed;

        public TransformMovement(Transform transform, float speed)
        {
            _transform = transform;
            _speed = speed;
        }

        public void Move(Vector2 movement)
        {
            _transform.Translate(movement * _speed, Space.World);
        }
    }
}