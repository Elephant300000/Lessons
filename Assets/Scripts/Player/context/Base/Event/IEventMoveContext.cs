using Player.PlayerStates.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Context
{
    public interface IEventMoveContext  : IContextBase
    {
         event Action<MoveStateType> onChangeState;
            void InvokeAction();
    }
}