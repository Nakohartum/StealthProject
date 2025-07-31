using System;
using _Root.Code.EnemyFeature.EnemyState;
using Cysharp.Threading.Tasks;
using GameOne.Player;
using UnityEngine;

namespace _Root.Code.EnemyFeature.EnemyFOVFeature
{
    public class EnemyFOV 
    {
        private float _viewRadius;
        private float _viewAngle;
        private LayerMask _viewMask;
        private LayerMask _obstacleMask;
        private Transform _transform;
        private EnemyStateMachine _enemyStateMachine;
        private bool _hasSeenPlayerPreviously = false;
        public EnemyFOV(float viewRadius, float viewAngle, LayerMask viewMask, LayerMask obstacleMask, Transform transform, EnemyStateMachine enemyStateMachine)
        {
            _viewRadius = viewRadius;
            _viewAngle = viewAngle;
            _viewMask = viewMask;
            _obstacleMask = obstacleMask;
            _transform = transform;
            _enemyStateMachine = enemyStateMachine;
        }

        public void DetectPlayer()
        {
            bool playerSeenThisFrame = false;
            Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(_transform.position, _viewRadius, _viewMask);
            foreach (var target in targetsInViewRadius)
            {
                if (target.TryGetComponent(out PlayerView playerView))
                {
                    Vector2 directionToTarget = (target.transform.position - _transform.position).normalized;
                    float angle = Vector2.Angle(_transform.up, directionToTarget);
                    if (angle < _viewAngle / 2)
                    {
                        float distanceToTarget = Vector2.Distance(_transform.position, target.transform.position);
                        RaycastHit2D hit = Physics2D.Raycast(_transform.position, directionToTarget, distanceToTarget,
                            _obstacleMask);
                        if (!hit)
                        {
                            _enemyStateMachine.SetChasingState(playerView);
                            playerSeenThisFrame = true;
                            _hasSeenPlayerPreviously = playerSeenThisFrame;
                            return;
                        }
                    }
                }
            }
            Debug.Log("Player seen this frame: " + playerSeenThisFrame);
            Debug.Log("Player seen previously: " + _hasSeenPlayerPreviously);
            if (!playerSeenThisFrame && _hasSeenPlayerPreviously)
            {
                _hasSeenPlayerPreviously = false;
                _enemyStateMachine.SetChasingState(null);
            }
        }
    }
}