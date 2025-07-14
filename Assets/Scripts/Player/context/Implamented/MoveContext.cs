using Player.PlayerStates.Base;
using System;
namespace Character.Context
{
    public class MoveContext : IMoveContext
    {
        MoveStateType _currentStateType;
        public MoveStateType currentMoveType => _currentStateType;

        public event Action<MoveStateType> onChangeMoveState;

        public void InvokeAction()
        {
            onChangeMoveState?.Invoke(currentMoveType);
        }

        public void SetMoveType(MoveStateType moveStateType)
        {
            if (moveStateType == _currentStateType) return;
            _currentStateType = moveStateType;
        }




        bool _isIdle;
        public bool isIdle => _isIdle;

        bool _isWalking;
        public bool isWalking => _isWalking;

        bool _isRunning ;
        public bool isRunning => _isRunning;

        bool _isSprinting ;
        public bool isSprinting => _isSprinting;

      
  

        public void Enter()
        { 
        }

        public void Exit()
        { 
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