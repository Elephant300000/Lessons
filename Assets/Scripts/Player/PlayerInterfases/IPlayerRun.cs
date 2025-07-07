using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace Player.PlayerInterfases
{
    public interface IPlayerRun : IBehaviourBase
    {
        void Run(InputAction.CallbackContext ctx);
    }
}