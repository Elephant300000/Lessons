using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public interface IPlayerMove 
{
    void InputMove(InputAction.CallbackContext ctx);
    void Jump();
}
