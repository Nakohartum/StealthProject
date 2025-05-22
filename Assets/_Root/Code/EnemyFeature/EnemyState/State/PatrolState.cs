using System;
using System.Collections.Generic;
using _Root.Code.AStar.Pathfinder;
using _Root.Code.EnemyFeature.EnemyFOVFeature;
using _Root.Code.MoveFeature;
using UnityEngine;

namespace _Root.Code.EnemyFeature.EnemyState.State
{
    public class PatrolState : IEnemyState
    {
        private Vector2[] _patrolPoints;
        private IMovable _movable;
        private readonly Transform _transform;
        public event Func<EnemyState, IEnemyState> OnStateChange;

        private int _currentPatrolPoint = -1;
        private PathfinderPresenter _pathfinderPresenter;
        private bool _isMoving;
        private Queue<Vector3> _pathQueue = new Queue<Vector3>();

        public PatrolState(Vector2[] patrolPoints, IMovable movable, Transform transform, 
            PathfinderPresenter pathfinderPresenter)
        {
            _patrolPoints = patrolPoints;
            _movable = movable;
            _transform = transform;
            _pathfinderPresenter = pathfinderPresenter;
        }

        public void Enter()
        {
            _currentPatrolPoint = 0;
            CalculatePath(_patrolPoints[_currentPatrolPoint]);
        }

        public void Exit()
        {
            _isMoving = false;
            _currentPatrolPoint = -1;
        }

        public void UpdateState()
        {
            if (_isMoving)
            {
                MoveToPoint();
            }
            else
            {
                _currentPatrolPoint = (_currentPatrolPoint + 1) % _patrolPoints.Length;
                CalculatePath(_patrolPoints[_currentPatrolPoint]);
            }
        }
        
        private void RotateTowardsMovingSide(Vector2 obj)
        {
            float angle = Vector2.SignedAngle(_transform.transform.up, obj);
            _transform.Rotate(0,0,angle);
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

                if (_pathQueue.Count == 0)
                {
                    _isMoving = false;
                    _movable.Move(Vector2.zero); 
                }
            }
        }
        
        public void CalculatePath(Vector3 targetWorldPosition)
        {
            var path = _pathfinderPresenter.FindPath(_transform.position, targetWorldPosition);
            if (path == null || path.Count == 0) return;

            _pathQueue.Clear();
            foreach (var node in path)
                _pathQueue.Enqueue(_pathfinderPresenter.Model.GridToWorld(node));

            _isMoving = true;
        }

        private void StartPatrol()
        {
            
        }
    }
}