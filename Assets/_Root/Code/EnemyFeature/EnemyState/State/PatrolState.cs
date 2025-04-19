using _Root.Code.MoveFeature;
using UnityEngine;

namespace _Root.Code.EnemyFeature.EnemyState.State
{
    public class PatrolState : IEnemyState
    {
        private Vector2[] _patrolPoints;
        private IMovable _movable;
        private int _currentPatrolPoint = -1;

        public PatrolState(Vector2[] patrolPoints, IMovable movable, int currentPatrolPoint)
        {
            _patrolPoints = patrolPoints;
            _movable = movable;
            _currentPatrolPoint = currentPatrolPoint;
        }

        public void Enter()
        {
            _currentPatrolPoint = 0;
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateState()
        {
            throw new System.NotImplementedException();
        }

        private void StartPatrol()
        {
            
        }
    }
}