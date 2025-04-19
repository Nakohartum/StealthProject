using _Root.Code.EnemyFeature.Enemy.EnemyModel;
using _Root.Code.MoveFeature;
using UnityEngine;
using Zenject;

namespace _Root.Code.EnemyFeature.Enemy.Installer
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemySO _enemySo;

        public override void InstallBindings()
        {
            var go = GetComponent<EnemyView.EnemyView>();

            var health = new Health.Health(_enemySo.Health.MaxHeatlh);
            var model = _enemySo.Model;
            var enemyModel = new EnemyModel.EnemyModel(health, model.Speed, model.RotationSpeed, go.transform.position);
            var move = CreateMove(go.GetComponent<Rigidbody2D>(), model.Speed);
            var enemyPresenter = new EnemyPresenter.EnemyPresenter(enemyModel, go, move); 
        }

        private IMovable CreateMove(Rigidbody2D component, float speed)
        {
            return new PhysicsMovement(component, speed);
        }
    }
}