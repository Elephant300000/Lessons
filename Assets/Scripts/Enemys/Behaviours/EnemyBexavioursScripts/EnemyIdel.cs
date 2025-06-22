using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdel : BehavioursEnemyBase
{
    public EnemyIdel(EnemyBase enemy, IBehaviourHandler behaviourHandler) : base(enemy, behaviourHandler)
    {
        behaviourHandler.Registr<IEnemyIdel>(this);

    }
    public override void EneterBexaviour()
    {
    }
    public override void ExidBexaviour()
    {
    }
    public override void FixedUpdate()
    {
    }
    public override void Update()
    {
        if (enemy.IsIdel)
        {
            RandomRotate();
            LookRotate();
        }

    }
    public override void LateUpdate()
    {
    }
    
}
