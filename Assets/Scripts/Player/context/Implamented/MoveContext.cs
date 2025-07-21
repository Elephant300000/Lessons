using Player.PlayerStates.Base;
using System;
namespace Character.Context
{
    public class MoveContext : IMoveContext
    {
        MoveStateType _currentStateType;
        public MoveStateType currentMoveType => _currentStateType;

        MoveStateType IStateMoveContext.currentMoveType { get => currentMoveType; set => throw new NotImplementedException(); }
        public bool isIdle 
        { get;
        set; }
        public bool isMove 
        { get; 
        set; }
        public bool isJump 
        { get;
        set; }

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




        

        public void Enter()
        { 
        }

        public void Exit()
        { 
        }

        public void SetIdle(bool isIdle)
        {
            this.isIdle = isIdle;
        }

        public void SetJump(bool isJump)
        {
            this.isJump = isJump;
        }

        public void SetMove(bool isMove)
        {
            this.isMove = isMove;
        }

        
    }
}