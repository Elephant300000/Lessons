using Player.PlayerStates.Base;
using System;

namespace Character.Context
{
    public interface IEventMoveContext  : IContextBase
    {
         event Action<MoveStateType> onChangeMoveState;
        void InvokeAction();
    }
}