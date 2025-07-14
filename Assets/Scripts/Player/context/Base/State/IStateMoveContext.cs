using Player.PlayerStates.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Character.Context
{
    public interface IStateMoveContext : IContextBase
    {
        MoveStateType currentMoveType { get; }
        bool isIdle { get; }
        bool isWalking { get; }
        bool isRunning { get; }
        bool isSprinting { get; } 
    }
}