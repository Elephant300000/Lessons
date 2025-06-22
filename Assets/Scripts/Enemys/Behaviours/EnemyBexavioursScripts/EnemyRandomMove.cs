using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomMove : BehavioursEnemyBase
{
    public EnemyRandomMove(EnemyBase enemy, IBehaviourHandler behaviourHandler) : base(enemy, behaviourHandler)
    {
        behaviourHandler.Registr<IEnemyRandomMove>(this);

    }
    private Transform _enemyTr;
    private Transform _playerTr;
    private Rigidbody _myRb;



    public override void RandomMove()
    {
        _enemyTr = enemy._enemyTr;
        _playerTr = enemy._playerTr;
        if (enemy.IsRandomMove)
        {
            Moving(_enemyTr.forward);
        }
    }

    public override void FixedUpdate()
    {
        RandomMove();
        RandomRotate();
    }
    public override void EneterBexaviour()
    {

        _myRb = enemy._myRb;
    }
}
