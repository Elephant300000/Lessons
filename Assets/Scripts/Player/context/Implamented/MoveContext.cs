using Player.PlayerStates.Base;
using System;
namespace Character.Context
{
    public class MoveContext : IMoveContext
    {
        public event Action<MoveStateType> onChangeState;

        bool _isIdle;
        public bool isIdle => _isIdle;

        bool _isWalking;
        public bool isWalking => _isWalking;

        bool _isRunning ;
        public bool isRunning => _isRunning;

        bool _isSprinting ;
        public bool isSprinting => _isSprinting;

        MoveStateType _currentStateType;
        public MoveStateType currentStateType => _currentStateType;

        public void Enter()
        { 
        }

        public void Exit()
        {
            
        }

        public void InvokeAction(MoveStateType type)
        {
            onChangeState?.Invoke(type);
        }
         

        public void SetIdle(bool isIdle)
        {
            _isIdle = isIdle;
        }

        public void SetWalk(bool isWalk)
        {
            _isWalking = isWalk;
        }

        public void SetRun(bool isRun)
        {
            _isRunning = isRun;
        }

        public void SetSPrint(bool isSprint)
        {
            _isSprinting = isSprint;
        }
 
    }
}