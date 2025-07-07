using System.Collections.Generic;
using Enemy.Context;

namespace State.EnemyState
{
    
    public abstract class EnemyStateBase : IStateGame
    {
        public  EnemyStateBase(IStateMachine _stateHandler, IBehaviourHandler behaviourHandler, EnemyBase enemy)
        {
            this._stateHandler = _stateHandler;
            this.behaviourHandler = behaviourHandler;
            _enemy = enemy;
        }

        protected readonly IStateMachine _stateHandler;
        public IBehaviourHandler behaviourHandler;
        protected EnemyBase _enemy;

        protected List<IBehaviourBase> behaviours = new();
        public abstract void EnterState();
        public abstract void ExitState();
        public abstract void UpdateState();
        public abstract void FixedUpdateState();
        public abstract void LateUpdateState();
    }
    public enum EnemyStateType
    {
        Idel,
        Follow,
        Move
    }
}
