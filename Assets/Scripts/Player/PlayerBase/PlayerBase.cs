using Player.PlayerStates.StateHandler;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

//[RequireComponent(Rigidbody)]

public class PlayerBase : MonoBehaviour 
{
    public bool IsIdel;
    public bool IsRun;
    public bool IsWalk;
    public bool IsJump;
    public bool IsShoot;

    private PlayerStateHandler _stateHandler = new();


    private void FixedUpdate()
    {
        _stateHandler.FixedUpdateState();
    }

    private void LateUpdate()
    {
        _stateHandler.LateUpdateState();
    }









    //public float MHp = 6;
    //public float Hp;
    //public Transform CameraTr;
    private InputMap _input;
    //private Rigidbody _myRb;
    //private PlayerStates current;
    //private Vector3 _inputAxis;
    //private bool _isRunning;


    private void Start()
    {
        //Hp = MHp;
        _input = new();
        //_myRb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _input = new();
        _input.Enable();
        _input.Player.Shoot.performed += ctx => Shoot();
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
    private void Shoot()
    {
        IsShoot = true;
        Invoke(nameof(AShoot), 0.1f);
    }
    private void AShoot()
    {
        IsShoot = false;
    }
    private void RunIsFalse()
    {
        IsRun = false;
    }

    private void OnDisable()
    {
        _input.Player.Shoot.performed += ctx => Shoot();
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
        InputMove();
        IsIdel = !IsRun & !IsWalk & !IsJump & !IsShoot;
    }

    //private void Update()
    //{
    //    Run(_inputAxis);
    //    Moving(_inputAxis);
    //    if (current == PlayerStates.Idel)
    //    {
    //        Idel();
    //    }
    //}

    //public void InputMove(InputAction.CallbackContext ctx)
    //{
    //    current = PlayerStates.Move;
    //    _inputAxis = new Vector3(ctx.ReadValue<Vector2>().x, 0, ctx.ReadValue<Vector2>().y);

    //}
    //public void Moving(Vector3 axis)
    //{
    //    _myRb.MovePosition(transform.position + axis * 15 * Time.deltaTime);
    //}

    //public void Jump()
    //{
    //    current = PlayerStates.Move;
    //    _myRb.AddForce(new Vector3(0, 6, 0), ForceMode.Impulse);
    //}

    //public void Idel()
    //{
    //    CameraTr.Rotate(new Vector3(Random.Range(-0.1f, 0.1f), 0, 0));
    //}

    //public void Run(Vector3 axis)
    //{
    //    if (_isRunning)
    //    {
    //        _myRb.MovePosition(transform.position + axis * 25 * Time.deltaTime);
    //    }
    //}

    //public void RunIsTrue()
    //{
    //    _isRunning = true;
    //}
    //public void RunIsFalse()
    //{
    //    _isRunning = false;
    //}

    //protected override void WeaponGo()
    //{
    //}

}


