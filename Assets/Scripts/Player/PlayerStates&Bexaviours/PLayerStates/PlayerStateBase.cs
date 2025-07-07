using Player.PlayerStates.StateHandler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.PlayerStates.Base
{
    public abstract class PlayerStateBase : IStateGame
    {
        public PlayerStateBase(IPlayerStateHandler _stateHandler, IBehaviourHandler behaviourHandler, PlayerBase pl)
        {
            this._stateHandler = _stateHandler;
            this.behaviourHandler = behaviourHandler;
            this.pl = pl;
        }

        protected readonly IPlayerStateHandler _stateHandler;
        public IBehaviourHandler behaviourHandler;
        public PlayerBase pl;

        protected List<IBehaviourBase> behaviours = new();
        public abstract void EnterState();
        public abstract void ExitState();
        public abstract void UpdateState();
        public abstract void FixedUpdateState();
        public abstract void LateUpdateState();
    }
    public enum PlayerStateType
    {
        Idel,
        Jump,
        Move
    }

    public interface IStateGame
    {
        void EnterState();
        void ExitState();
        void UpdateState();
        void FixedUpdateState();
        void LateUpdateState();

    }
}