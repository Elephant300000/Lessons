using UnityEngine;
using Character.Context;


[RequireComponent(typeof(Rigidbody))] 
public class PlayerInfo : MonoBehaviour
{
    public Rigidbody rbPlayer { get; private set; }
    public Transform trPlayer { get; private set; }
    public IMoveContext ctxMove { get; private set; }
    public float speedWalk = 3;
    public float speedRun = 6;
    public float speedSprint = 8;
     
    private void Awake()
    {
        rbPlayer = GetComponent<Rigidbody>();
        trPlayer = GetComponent<Transform>();
        ctxMove = new MoveContext();
    }
    private void OnEnable()
    {
        ctxMove.Enter();
    }
    private void OnDisable()
    {
        ctxMove.Exit();
    }
}


