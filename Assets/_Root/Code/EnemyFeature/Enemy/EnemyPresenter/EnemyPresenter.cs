using _Root.Code.MoveFeature;
using UnityEngine;
using Zenject;

namespace _Root.Code.EnemyFeature.Enemy.EnemyPresenter
{
    public class EnemyPresenter : ITickable
    {
        private EnemyModel.EnemyModel _enemyModel;
        private EnemyView.EnemyView _enemyView;
        private IMovable _movable;

        public EnemyPresenter(EnemyModel.EnemyModel enemyModel, EnemyView.EnemyView enemyView, IMovable movable)
        {
            _enemyModel = enemyModel;
            _enemyView = enemyView;
            _movable = movable;
        }
        
        
        public void Tick()
        {
            _movable.Move(Vector2.zero);
        }
    }
}