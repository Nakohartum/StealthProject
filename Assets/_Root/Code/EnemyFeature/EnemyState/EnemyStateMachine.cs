using System;
using System.Collections.Generic;
using _Root.Code.EnemyFeature.EnemyFOVFeature;
using _Root.Code.EnemyFeature.EnemyState.State;
using GameOne.Player;
using UnityEngine;

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

        public void SetChasingState(PlayerView obj)
        {
            var chasingState = SetState(EnemyState.Chasing);
            (chasingState as ChasingState).SetTarget(obj == null ? null : obj.transform);
        }

        public IEnemyState SetState(EnemyState state)
        {
            if (_states.TryGetValue(state, out var value))
            {
                if (value == _currentState)
                {
                    return _currentState;
                }
                _currentState?.Exit();
                _currentState = value;
                _currentState?.Enter();
            }
            return _currentState;
        }

        public void UpdateState()
        {
            Debug.Log(_currentState.GetType().Name);
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