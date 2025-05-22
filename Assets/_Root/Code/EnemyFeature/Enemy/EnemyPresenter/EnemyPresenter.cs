using System;
using System.Collections.Generic;
using _Root.Code.AStar.Grid;
using _Root.Code.AStar.Pathfinder;
using _Root.Code.EnemyFeature.EnemyFOVFeature;
using _Root.Code.EnemyFeature.EnemyState;
using _Root.Code.EnemyFeature.EnemyState.State;
using _Root.Code.LevelFeature;
using _Root.Code.MoveFeature;
using UnityEngine;
using Zenject;

namespace _Root.Code.EnemyFeature.Enemy.EnemyPresenter
{
    public class EnemyPresenter : ITickable, ILevelReadyListener, IDisposable
    {
        private EnemyModel.EnemyModel _enemyModel;
        private EnemyView.EnemyView _enemyView;
        private bool _isMoving;
        private GlobalManagers.LevelManager _levelManager;
        private EnemyStateMachine _enemyStateMachine;
        private EnemyFOV _enemyFOV;

        [Inject]
        public EnemyPresenter(EnemyModel.EnemyModel enemyModel, EnemyView.EnemyView enemyView, 
            GlobalManagers.LevelManager levelManager, EnemyStateMachine enemyStateMachine, EnemyFOV enemyFOV)
        {
            _enemyModel = enemyModel;
            _enemyView = enemyView;
            _levelManager = levelManager;
            _enemyStateMachine = enemyStateMachine;
            _enemyFOV = enemyFOV;
            _levelManager.OnLevelLoaded += OnLevelLoaded;
        }
        
        
        public void Tick()
        {
            _enemyFOV.DetectPlayer();
                
            _enemyStateMachine.UpdateState();
        }

        public void SetState(EnemyState.EnemyState state)
        {
            _enemyStateMachine.SetState(state);
        }

        public void OnLevelLoaded()
        {
           SetState(EnemyState.EnemyState.Patrolling);
        }

        public void Dispose()
        {
            _levelManager.OnLevelLoaded -= OnLevelLoaded;
        }
    }
}