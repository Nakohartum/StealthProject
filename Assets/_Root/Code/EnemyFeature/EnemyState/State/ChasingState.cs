using System;
using System.Collections.Generic;
using _Root.Code.AStar.Pathfinder;
using _Root.Code.Miscellanious;
using _Root.Code.MoveFeature;
using UnityEngine;

namespace _Root.Code.EnemyFeature.EnemyState.State
{
    public class ChasingState : IEnemyState
    {
        private Transform _target;
        private readonly Transform _transform;
        private readonly float _speedMultiplier;
        private readonly float _chasingDuration;
        private readonly IMovable _movable;
        private PathfinderPresenter _pathfinderPresenter;
        private bool _isChasing;
        private bool _hasSeenTargetPreviously;
        private float _lastPointChangeTime = 0f;
        private Vector3 _lastTargetPosition;
        
        private Queue<Vector3> _pathQueue = new Queue<Vector3>();

        public ChasingState(Transform transform, float speedMultiplier, float chasingDuration, IMovable movable, PathfinderPresenter pathfinderPresenter)
        {
            _transform = transform;
            _speedMultiplier = speedMultiplier;
            _chasingDuration = chasingDuration;
            _movable = movable;
            _pathfinderPresenter = pathfinderPresenter;
        }


        public void Enter()
        {
        }

        public void Exit()
        {
            _isChasing = false;
            _target = null;
        }

        public void UpdateState()
        {
            if (!_isChasing && !_hasSeenTargetPreviously)
            {
                return;
            }

            if (_isChasing)
            {
                if (Time.time -_lastPointChangeTime > InGameValues.CHASING_POINT_UPDATE_INTERVAL 
                    && Vector3.Distance(_target.position, _lastTargetPosition) > InGameValues.CHASING_POINT_UPDATE_DISTANCE)
                {
                    _lastTargetPosition = _target.position;
                    CalculatePath(_lastTargetPosition);
                   
                    _lastPointChangeTime = Time.time;
                }
            }
            MoveToPoint();
        }

        private void MoveToPoint()
        {
            if (_pathQueue.Count > 0)
            {
                Vector3 target = _pathQueue.Peek();
                Vector3 direction = (target - _transform.position).normalized;
                _movable.Move(direction);
                RotateTowardsMovingSide(direction);
                if (Vector3.Distance(_transform.position, target) < 0.1f)
                {
                    _pathQueue.Dequeue();
                }
            }
            else
            {
                _movable.Move(Vector2.zero);

                if (!_isChasing && _hasSeenTargetPreviously)
                {
                    Debug.Log("Done chasing");
                    _hasSeenTargetPreviously = false;
                    OnStateChange?.Invoke(EnemyState.Patrolling);
                }
            }
        }
        
        private void RotateTowardsMovingSide(Vector2 obj)
        {
            float angle = Vector2.SignedAngle(_transform.transform.up, obj);
            _transform.Rotate(0,0,angle);
        }

        public void CalculatePath(Vector3 targetPosition)
        {
            var path = _pathfinderPresenter.FindPath(_transform.position, targetPosition);
            _pathQueue.Clear();
            foreach (var node in path)
            {
                _pathQueue.Enqueue(_pathfinderPresenter.Model.GridToWorld(node));
            }
            
        }
        
        public void SetTarget(Transform target)
        {
            _isChasing = target != null;
            if (_isChasing)
            {
                _target = target;
                _lastTargetPosition = _target.position;
                CalculatePath(_lastTargetPosition);
            }
            else
            {
                if (_target != null && target == null)
                {
                    _target = target;
                    _hasSeenTargetPreviously = true;
                }
                else
                {
                    _hasSeenTargetPreviously = false;
                }
            }
        }

        public event Func<EnemyState, IEnemyState> OnStateChange;
    }
}