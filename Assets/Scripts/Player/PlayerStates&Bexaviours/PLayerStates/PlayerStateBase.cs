using Player.PlayerStates.StateHandler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.PlayerStates.Base
{
    public abstract class PlayerStateBase : IAbstractState
    {
        public PlayerStateBase(IPlayerStateHandler _stateHandler, IBehaviourHandler behaviourHandler, PlayerInfo pl)
        {
            this._stateHandler = _stateHandler;
            this.behaviourHandler = behaviourHandler;
            this.pl = pl;
        }

        protected readonly IPlayerStateHandler _stateHandler;
        public IBehaviourHandler behaviourHandler;
        public PlayerInfo pl;

        protected List<IBehaviourBase> behaviours = new();
        public abstract void EnterState();
        public abstract void ExitState();
        public abstract void UpdateState();
        public abstract void FixedUpdateState();
        public abstract void LateUpdateState();
    }
   

    public interface IAbstractState
    {
        void EnterState();
        void ExitState();
        void UpdateState();
        void FixedUpdateState();
        void LateUpdateState();

    }
    public enum PlayerStateType
    {
        Idle,
        Jump,
        Move
    }
}