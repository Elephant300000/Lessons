using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomRotate : BehavioursEnemyBase
{
    public EnemyRandomRotate(EnemyBase enemy, IBehaviourHandler behaviourHandler) : base(enemy, behaviourHandler)
    {
        behaviourHandler.Registr<IEnemyRandomRotate>(this);

    }

    private float _time;
    private Transform _enemyTr;
    private Transform _playerTr;
    private Rigidbody _myRb;

    public override void RandomRotate()
    {
        
            if (_time <= Time.time || enemy._isInCollision)
            {
                Vector3 _dierectionOfRotate = enemy.RandomVector3(-10, 10);
                _time = Time.time + Random.Range(3, 6);
            }
            Quaternion rotate = Quaternion.LookRotation(enemy._dierectionOfRotate);
            Rotate(rotate);
        
    }

    public override void EneterBexaviour()
    {
        _enemyTr = enemy._enemyTr;
        _playerTr = enemy._playerTr;
        _myRb = enemy._myRb;
    }
}
