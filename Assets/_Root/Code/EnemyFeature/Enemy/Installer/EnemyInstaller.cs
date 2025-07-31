using System.Collections.Generic;
using System.Linq;
using _Root.Code.AStar.Pathfinder;
using _Root.Code.EnemyFeature.Enemy.EnemyModel;
using _Root.Code.EnemyFeature.EnemyFOVFeature;
using _Root.Code.EnemyFeature.EnemyState;
using _Root.Code.EnemyFeature.EnemyState.State;
using _Root.Code.MoveFeature;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Root.Code.EnemyFeature.Enemy.Installer
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private Transform[] _patrolPoints;
        [SerializeField] private EnemySO _enemySo;
        [Inject] private PathfinderPresenter _pathfinderPresenter;

        public override void InstallBindings()
        {
            var go = GetComponent<EnemyView.EnemyView>();
            var health = new Health.Health(_enemySo.Health.MaxHeatlh);
            var enemyModel = new EnemyModel.EnemyModel(health, _enemySo.Speed, _enemySo.RotationSpeed, go.transform.position);
            var move = CreateMove(go.GetComponent<Rigidbody2D>(), _enemySo.Speed);
            
            var stateMachine = new EnemyStateMachine(new Dictionary<EnemyState.EnemyState, IEnemyState>
            {
                { EnemyState.EnemyState.Patrolling , new PatrolState(_patrolPoints.Select(q => (Vector2)q.position).ToArray(), move, 
                    go.transform, _pathfinderPresenter)
                },
                {
                    EnemyState.EnemyState.Chasing, new ChasingState(go.transform, 1.5f, 3f, move, _pathfinderPresenter)
                }
            });
            var enemyFOV = new EnemyFOV(_enemySo.ViewRadius, _enemySo.ViewAngle, _enemySo.PlayerMask, _enemySo.ObstacleMask, go.transform, stateMachine);
            
        }

        private IMovable CreateMove(Rigidbody2D component, float speed)
        {
            return new PhysicsMovement(component, speed);
        }
    }
}