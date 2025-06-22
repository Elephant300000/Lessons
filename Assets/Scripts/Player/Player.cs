using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//[RequireComponent(Rigidbody)]

public class Player : MonoBehaviour
{
    //public float MHp = 6;
    //public float Hp;
    //public Transform CameraTr;
    //private InputMap _input;
    //private Rigidbody _myRb;
    //private PlayerStates current;
    //private Vector3 _inputAxis;
    //private bool _isRunning;


    //private void Start()
    //{
    //    Hp = MHp;
    //    _input = new(); 
    //    _myRb = gameObject.GetComponent<Rigidbody>();
    //}
    
    //private void OnEnable()
    //{
    //    _input = new();
    //    _input.Enable();
    //    _input.Player.Move.performed += ctx => InputMove(ctx);
    //    _input.Player.Move.canceled += ctx => InputMove(ctx);
    //    _input.Player.Run.performed += ctx => RunIsTrue();
    //    _input.Player.Run.canceled += ctx => RunIsFalse();
    //    _input.Player.Jump.performed += ctx => Jump();
    //}
    //private void OnDisable()
    //{
    //    _input.Player.Move.performed -= ctx => InputMove(ctx);
    //    _input.Player.Move.canceled -= ctx => InputMove(ctx);
    //    _input.Player.Run.performed -= ctx => RunIsTrue();
    //    _input.Player.Run.canceled -= ctx => RunIsFalse();
    //    _input.Player.Jump.performed -= ctx => Jump();
    //    _input.Disable();
    //}

    //private void Update()
    //{
    //    Run(_inputAxis);
    //    Moving(_inputAxis);
    //    if(current == PlayerStates.Idel)
    //    {
    //        Idel();
    //    }
    //}

    //public void InputMove(InputAction.CallbackContext ctx)
    //{
    //    current = PlayerStates.Move;
    //    _inputAxis = new Vector3(ctx.ReadValue<Vector2>().x,0, ctx.ReadValue<Vector2>().y);
       
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
    //    CameraTr.Rotate(new Vector3(Random.Range(-0.1f, 0.1f),0,0));
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

    //private enum PlayerStates
    //{
    //    Idel,
    //    Move,
    //    Run,
    //}

    //private enum IsHaveWeapon
    //{
    //    HaveWeapon,
    //    DontHaveWeapon
    //}
    
}


