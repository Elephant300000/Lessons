using Player.PlayerStates.Base;
using System;
using System.Collections.Generic;

namespace Player.PlayerStates.StateHandler
{
    public class PlayerFSM : IStateHandler
    {
        private Base.IStateMove _currentState;
        private MoveStateType _currentStateType;
        private readonly Dictionary<MoveStateType, Base.IStateMove> states = new();
        private readonly Dictionary<MoveStateType, List<Func<MoveStateType>>> transitions = new();
        public void SetState(MoveStateType type)
        {
            if (_currentStateType.Equals(type)) return;
            if (states.ContainsKey(type))
            {
                _currentState?.ExitState();
                _currentState = states[type];
                _currentStateType = type;
                _currentState?.EnterState();
            } 
        }
        public void UpdateState()
        {
            _currentState?.UpdateState();
        }
        public void LateUpdateState()
        {
            _currentState?.LateUpdateState();
        }
        public void FixedUpdateState()
        {
            _currentState?.FixedUpdateState();
        }

        public void RegisteringState(MoveStateType type, Base.IStateMove state)
        {
            if (!states.ContainsKey(type))
                states[type] = state;
        }
        
        
    }
    public interface IStateHandler
    {
        public void UpdateState();
        public void LateUpdateState();
        public void FixedUpdateState();
        public void RegisteringState(MoveStateType type, Base.IStateMove state);
        public void SetState(MoveStateType type);
    }
}