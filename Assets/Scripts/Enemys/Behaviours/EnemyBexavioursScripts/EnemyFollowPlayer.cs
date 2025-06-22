using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : BehavioursEnemyBase
{


    public EnemyFollowPlayer(EnemyBase enemy, IBehaviourHandler behaviourHandler) : base(enemy, behaviourHandler)
    {
        behaviourHandler.Registr<IEnemyFollowTarget>(this);

    }
    private Transform _enemyTr;
    private Transform _playerTr;
    private Rigidbody _myRb;

    public override void FollowPlayer()
    {
        _enemyTr = enemy._enemyTr;
        _playerTr = enemy._playerTr;
        if (enemy.IsFollow)

        {
            Moving(_playerTr.position - _enemyTr.position);
        }
    }

    public override void FixedUpdate()
    {
        FollowPlayer();
        LookRotate();
    }
    public override void EneterBexaviour()
    {

        _myRb = enemy._myRb;
    }

}
