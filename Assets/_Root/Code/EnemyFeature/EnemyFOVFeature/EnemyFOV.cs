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
        
        public PlayerView PlayerView { get; private set; }
        public bool CanSeePlayer => PlayerView != null;

        public EnemyFOV(float viewRadius, float viewAngle, LayerMask viewMask, LayerMask obstacleMask, Transform transform)
        {
            _viewRadius = viewRadius;
            _viewAngle = viewAngle;
            _viewMask = viewMask;
            _obstacleMask = obstacleMask;
            _transform = transform;
        }

        public void DetectPlayer()
        {
            PlayerView = null;
            
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
                            PlayerView = playerView;
                        }
                    }
                }
            }
        }

        public void ResetDetectedPlayer()
        {
            PlayerView = null;
        }
    }
}