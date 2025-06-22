using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : BehavioursEnemyBase
{
    public EnemyMove(EnemyBase enemy, IBehaviourHandler behaviourHandler) : base(enemy, behaviourHandler)
    {
        behaviourHandler.Registr<IEnemyMove>(this);

    }
    private Transform _enemyTr;
    private Transform _playerTr;
    private Rigidbody _myRb;
    private void CashLincs()
    {
        _enemyTr = enemy._enemyTr;
        _playerTr = enemy._playerTr;
        _myRb = enemy._myRb;
    }

    public override void Moving(Vector3 _dierectionOfMove)
    {
        CashLincs();
        _myRb.MovePosition(_myRb.position + _dierectionOfMove * enemy._speedOfMove * Time.fixedDeltaTime);
    }
}
