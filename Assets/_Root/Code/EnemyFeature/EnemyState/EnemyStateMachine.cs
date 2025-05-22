using System;
using System.Collections.Generic;
using _Root.Code.EnemyFeature.Enemy.EnemyPresenter;
using _Root.Code.EnemyFeature.EnemyState.State;

namespace _Root.Code.EnemyFeature.EnemyState
{
    public class EnemyStateMachine
    {
        private Dictionary<EnemyState, IEnemyState> _states;
        private IEnemyState _currentState;
        
        public EnemyStateMachine(Dictionary<EnemyState, IEnemyState> states)
        {
            _states = states;
            foreach (var state in states.Values)
            {
                state.OnStateChange += SetState;
            }
        }

        public IEnemyState SetState(EnemyState state)
        {
            if (_states.TryGetValue(state, out var value))
            {
                _currentState?.Exit();
                _currentState = value;
                _currentState?.Enter();
            }
            return _currentState;
        }

        public void UpdateState()
        {
            _currentState?.UpdateState();
        }

        
    }

    public enum EnemyState
    {
        Idle,
        Patrolling,
        Chasing,
        Attacking
    }
}