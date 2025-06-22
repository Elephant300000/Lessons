using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : BehavioursEnemyBase
{
    public EnemyRotate(EnemyBase enemy, IBehaviourHandler behaviourHandler) : base(enemy, behaviourHandler)
    {
        behaviourHandler.Registr<IEnemyRotate>(this);

    }

    public override void Rotate(Quaternion quaternion)
    {
        Quaternion lerpRotate = Quaternion.Slerp(enemy._enemyTr.rotation, quaternion, enemy._speedOfRotate * Time.fixedDeltaTime);
        enemy._myRb.MoveRotation(lerpRotate);
    }


}
