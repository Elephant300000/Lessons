using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookRotate : BehavioursEnemyBase
{

    public EnemyLookRotate(EnemyBase enemy, IBehaviourHandler behaviourHandler) : base(enemy, behaviourHandler)
    {
        behaviourHandler.Registr<IEnemyLookTarget>(this);

    }
    private Transform _enemyTr;
    private Transform _playerTr;
    private Rigidbody _myRb;


    public override void LookRotate()
    {
        _enemyTr = enemy._enemyTr;
        _playerTr = enemy._playerTr;
       
        
            Vector3 dierection = _playerTr.position - _enemyTr.position;
            dierection.y = 0;
            Quaternion rotate = Quaternion.LookRotation(dierection);
            Rotate(rotate);
        
    }

    public override void EneterBexaviour()
    {

        _myRb = enemy._myRb;
    }


}
