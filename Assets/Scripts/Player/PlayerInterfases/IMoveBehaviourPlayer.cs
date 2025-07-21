using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace Player.PlayerInterfases
{
    public interface IMoveBehaviourPlayer : IBehaviourBase
    {
        void InputMove(InputAction.CallbackContext ctx);
        void Jump();
    }
}