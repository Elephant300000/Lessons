using Player.PlayerStates.Base;
using System;
using System.Collections.Generic;

namespace Player.PlayerStates.StateHandler
{
    public class PlayerFSM : IPlayerStateHandler
    {
        private Base.IAbstractState _currentState;
        private PlayerStateType _currentStateType;
        private readonly Dictionary<PlayerStateType, Base.IAbstractState> states = new();
        private readonly Dictionary<PlayerStateType, List<Func<PlayerStateType>>> transitions = new();
        public void SetState(PlayerStateType type)
        {
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

        public void RegisteringState(PlayerStateType type, Base.IAbstractState state)
        {
            if (!states.ContainsKey(type))
                states[type] = state;
        }
        
        
    }
    public interface IPlayerStateHandler
    {
        public void UpdateState();
        public void LateUpdateState();
        public void FixedUpdateState();
        public void RegisteringState(PlayerStateType type, Base.IAbstractState state);
        public void SetState(PlayerStateType type);
    }
}