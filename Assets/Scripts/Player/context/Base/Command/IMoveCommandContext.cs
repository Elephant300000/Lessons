using Player.PlayerStates.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Character.Context 
{
    public interface IMoveCommandContext  : IContextBase
    { 
        void SetIdle(bool isIdle);
        void SetJump(bool isJump);
        void SetMove(bool isMove);
        void SetMoveType(MoveStateType moveStateType);
    }
}