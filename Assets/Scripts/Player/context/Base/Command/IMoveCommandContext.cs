using Player.PlayerStates.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Character.Context 
{
    public interface IMoveCommandContext  : IContextBase
    { 
        void SetIdle(bool isIdle);
        void SetWalk(bool isWalk);
        void SetRun(bool isRun);
        void SetSPrint(bool isSprint);
        void SetMoveType(MoveStateType moveStateType);
    }
}