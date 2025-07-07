using UnityEngine;

public class IdleBehaviour : EnemyBehaviourBase
{
    public IdleBehaviour(EnemyBase enemy) : base(enemy) { } 
    public override void EneterBexaviour() { }
    public override void ExitBexaviour() { }
    public override void UpdateBexaviour() { }
    public override void LateUpdateBexaviour() { }
    public override void FixedUpdateBexaviour()
    {
        if (enemy.context.isIdle)
        {
            Debug.Log("idle beh");
        }
    }
}
