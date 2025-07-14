using Player.PlayerStates.StateHandler;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody))]

public class PlayerInfo : MonoBehaviour
{
    private bool _isIdle;
    private bool IsIdle
    {
        get => _isIdle;
        set
        {
            if (_isIdle == value) return;
            _isIdle = value;
            OnChangeBool();
        }
    }
    private bool _isRun;

    private bool IsRun
    {
        get => _isRun;
        set
        {
            if (_isRun == value) return;
            _isRun = value;
            OnChangeBool();
        }
    }
    private bool _isWalk;

    private bool IsWalk
    {
        get => _isWalk;
        set
        {
            if (_isWalk == value) return;
            _isWalk = value;
            OnChangeBool();
        }
    }
    private bool _isJump;

    private bool IsJump
    {
        get => _isJump;
        set
        {
            if (_isJump == value) return;
            _isJump = value;
            OnChangeBool();
        }
    }
    private bool _isShoot;

    private bool IsShoot
    {
        get => _isShoot;
        set
        {
            if (_isShoot == value) return;
            _isShoot = value;
            OnChangeBool();
        }
    }

    public PlayerFSM _stateHandler = new();



    

    public void OnChangeBool() 
    {

        if (IsIdle & !IsJump) 
        {
            _stateHandler.SetState(Player.PlayerStates.Base.PlayerStateType.Idle);
            //Debug.Log("I");
        }
        if (IsRun || IsWalk & !IsJump)
        { 
            _stateHandler.SetState(Player.PlayerStates.Base.PlayerStateType.Move);
            //Debug.Log("M");
        }
        if (IsJump) 
        {
            _stateHandler.SetState(Player.PlayerStates.Base.PlayerStateType.Jump);
            //Debug.Log("J");
        }
    }

    private InputMap _input;

    private void Start()
    {
        _input = new();
    }

    private void OnEnable()
    {
        _input = new();
        _input.Enable();
        _input.Player.Shoot.performed += ctx => Shoot(ctx);
        _input.Player.Shoot.canceled += ctx => Shoot(ctx);
        _input.Player.Move.performed += ctx => InputMove();
        _input.Player.Move.canceled += ctx => InputAMove();
        _input.Player.Run.performed += ctx => RunIsTrue();
        _input.Player.Run.canceled += ctx => RunIsFalse();
        _input.Player.Jump.performed += ctx => Jump();
    }

    private void Jump()
    {
        IsJump = true;
        Invoke(nameof(AJump), 0.3f);
    }
    private void AJump()
    {
        IsJump = false;
    }
    private void Shoot(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
            IsShoot = true;
        else IsShoot = false;
    }

    private void RunIsFalse()
    {
        IsRun = false;
    }

    private void OnDisable()
    {
        _input.Player.Shoot.performed -= ctx => Shoot(ctx);
        _input.Player.Shoot.canceled -= ctx => Shoot(ctx);
        _input.Player.Move.performed -= ctx => InputMove();
        _input.Player.Move.canceled -= ctx => InputAMove();
        _input.Player.Run.performed -= ctx => RunIsTrue();
        _input.Player.Run.canceled -= ctx => RunIsFalse();
        _input.Player.Jump.performed -= ctx => Jump();
        _input.Disable();
    }

    private void RunIsTrue()
    {
        IsRun = true;
    }

    private void InputMove()
    {
        if (!IsRun)
            IsWalk = true;
        else IsWalk = false;
    }
    private void InputAMove()
    {
        IsRun = false;
        IsWalk = false;
    }
    private void Update()
    {
        IsIdle = !IsRun & !IsWalk & !IsJump & !IsShoot;
    }

    public enum MovingStates { }

}


