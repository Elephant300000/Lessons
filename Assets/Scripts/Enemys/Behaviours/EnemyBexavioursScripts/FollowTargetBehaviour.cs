using UnityEngine;

public class FollowTargetBehaviour : MoveBehaviour
{  
    public FollowTargetBehaviour(EnemyBase enemy) : base(enemy) { } 
    public override void EneterBexaviour() { } 
    public override void ExitBexaviour() { } 
    public override void UpdateBexaviour() { }
    public override void LateUpdateBexaviour() { }
    public override void FixedUpdateBehaviour()
    { 
        FollowPlayer(); 
    }
    public override void FollowPlayer()
    { 
        if (enemy.context.isFollowTarget)
        {
            var direction = (enemy._playerTr.position - enemy._enemyTr.position).normalized;
            Moving(direction);
        } 
        Debug.Log("Follow beh");
    }
}
