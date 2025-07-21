using Player.PlayerStates.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Character.Context
{
    public interface IStateMoveContext : IContextBase
    {
        MoveStateType currentMoveType { get; set; }
        bool isIdle { get; set; }
        bool isMove { get; set; }
        bool isJump { get; set; }
    }
}