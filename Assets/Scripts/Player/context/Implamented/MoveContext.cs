using Player.PlayerStates.Base;
using System;
namespace Character.Context
{
    public class MoveContext : IMoveContext
    {

        private MoveStateType _currentMoveType;

        public MoveStateType currentMoveType => _currentMoveType;

 

        bool _isWalking ;
        public bool isWalking => _isWalking;


        public bool isSprinting => throw new NotImplementedException();

        public bool isIdle => throw new NotImplementedException();

        public bool isRunning => throw new NotImplementedException();

        public bool isJump => throw new NotImplementedException();

        public event Action<MoveStateType> onChangeMoveState;

        public void InvokeAction()
        {
            onChangeMoveState?.Invoke(currentMoveType);
        }

        public void SetMoveType(MoveStateType moveStateType)
        {
            if (moveStateType == _currentMoveType) return;
            _currentMoveType = moveStateType;
        }
         
        public void Enter()
        { 
        }

        public void Exit()
        { 
        }

        public void SetIdle(bool isIdle)
        {
            //this._isIdle = isIdle;
        }

        public void SetJump(bool isJump)
        {
            //this._isJump = isJump;
        }

        public void SetMove(bool isMove)
        {
            //this._isRunning = isMove;
        }

        
    }
}