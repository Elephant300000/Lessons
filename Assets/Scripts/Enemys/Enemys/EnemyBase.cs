using System.Collections;
using UnityEngine;
using Enemy.Context;

[RequireComponent(typeof(Rigidbody))]
public abstract class EnemyBase : MonoBehaviour
{
    public Rigidbody _myRb { get; private set; }
    public Transform _playerTr { get; private set; }
    public Transform _enemyTr { get; private set; }
    public EnemyStateMoveContext context { get; private set; }
    [field: SerializeField] public float _speedOfRotate { get; private set; } = 1;
    [field: SerializeField] public float _speedOfMove { get; private set; } = 5; 
    [field: Range(10, 50), SerializeField] public float _minDistanceLookTarget { get; private set; } = 25;

    [field: Range(10, 50), SerializeField]  public float _minDistanceFollowTarget { get; private set; } = 25;
    
   
    

    void Awake()
    {
        
        _myRb = GetComponent<Rigidbody>();
        _enemyTr = GetComponent<Transform>();
        _playerTr = FindObjectOfType<PlayerBase>().transform;
        context = new EnemyStateMoveContext(this);
    }
    
}
