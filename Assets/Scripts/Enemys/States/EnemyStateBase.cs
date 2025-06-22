using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State.EnemyState
{
    
    public abstract class EnemyStateBase : IStateGame
    {
        public EnemyStateBase(IStateHandler _stateHandler, IBehaviourHandler behaviourHandler, EnemyBase enemy)
        {
            this._stateHandler = _stateHandler;
            this.behaviourHandler = behaviourHandler;
            _enemy = enemy;
        }

        protected readonly IStateHandler _stateHandler;
        public IBehaviourHandler behaviourHandler;
        protected List<IBehaviourBase> behaviours = new(); 
        protected EnemyBase _enemy;

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
