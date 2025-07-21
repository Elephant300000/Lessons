using UnityEngine;

public class Input : MonoBehaviour
{
    private InputMap _InputMap;
    private MainUpdate _MainUpdate;
    //private void OnEnable()
    //{
    //    _MainUpdate = FindAnyObjectByType<MainUpdate>(); 
    //    _InputMap = new InputMap();
    //    _InputMap.Enable();
    //    _InputMap.Player.Move.performed += ctx => Move();
    //    _InputMap.Player.Move.canceled += ctx => AMove();
    //    _InputMap.Player.Jump.performed += ctx => Jump();
    //    _InputMap.Player.Jump.canceled += ctx => AJump();
    //}
    //private void OnDisable()
    //{
    //    _InputMap.Player.Move.performed += ctx => Move();
    //    _InputMap.Player.Move.canceled += ctx => AMove();
    //    _InputMap.Player.Jump.performed += ctx => Jump();
    //    _InputMap.Player.Jump.canceled += ctx => AJump();
    //    _InputMap.Disable();
    //}
    //private void Move()
    //{
    //    _MainUpdate.MoveContext.SetMove(true);
    //    _MainUpdate.MoveContext.SetIdle(false);
    //}
    //private void AMove()
    //{
    //    _MainUpdate.MoveContext.SetMove(false);
    //    _MainUpdate.MoveContext.SetIdle(true);
    //}
    //private void Jump()
    //{
    //    _MainUpdate.MoveContext.SetJump(true);
    //}
    //private void AJump()
    //{
    //    _MainUpdate.MoveContext.SetJump(false);
    //}

}
