using System.Collections.Generic;

namespace Player.PlayerStates.Base
{
    public abstract class PlayerStateBase : IStateMove
    {
        public PlayerStateBase(IBehaviourHandler behaviourHandler)
        {
            this.behaviourHandler = behaviourHandler;
        }

        public IBehaviourHandler behaviourHandler;

        protected List<IBehaviourBase> behaviours = new();
        public abstract void EnterState();
        public abstract void ExitState();
        public abstract void UpdateState();
        public abstract void FixedUpdateState();
        public abstract void LateUpdateState();
    }
   

    public interface IStateMove
    {
        void EnterState();
        void ExitState();
        void UpdateState();
        void FixedUpdateState();
        void LateUpdateState();

    }
    public enum MoveStateType
    {
        Idle,
        Walking,
        Running,
        Sprinting,
        Jump // не нужен 
    }
}