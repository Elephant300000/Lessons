using Enemy.Context;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy.Action_
{
    public interface IAction
    {
        IStateMachine FSM { get; set; }
        void Subscribe(IContextEvent context);
        void Unsubscribe(IContextEvent context);
        void Exicute(IContextEvent context);
    }
}