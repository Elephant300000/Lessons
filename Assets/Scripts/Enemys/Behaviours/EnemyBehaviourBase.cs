using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehaviourBase :
    IMoveBehaviour,
    IRotateBehaviour,
    IRandomMoveBehaviour,
    IRandomRotateBehaviour,
    IFollowTargetBehaviour,
    ILookTargetBehaviour,
    IIdleBehaviour
{

    public EnemyBehaviourBase(EnemyBase enemy)
    {
        this.enemy = enemy;
    }
    public EnemyBase enemy { get; private set; }

    public abstract void EneterBexaviour();
    public abstract void ExitBexaviour(); 
    public abstract void UpdateBexaviour();
    public abstract void LateUpdateBexaviour();
    public abstract void FixedUpdateBehaviour();

    public virtual void FollowPlayer() { }
    public virtual void LookRotate() { }
    public virtual void Moving( Vector3 _dierectionOfRotate) { }
    public virtual void RandomMove() { }
    public virtual void RandomRotate() { }
    public virtual void Rotate(Quaternion quaternion) { }
}
