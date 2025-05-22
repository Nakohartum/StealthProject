using System;

namespace _Root.Code.EnemyFeature.EnemyState.State
{
    public interface IEnemyState
    {
        void Enter();
        void Exit();
        void UpdateState();
        event Func<EnemyState, IEnemyState> OnStateChange;
    }
}