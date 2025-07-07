using UnityEngine;

public class RandomMoveBehaviour : MoveBehaviour
{ 
    public RandomMoveBehaviour(EnemyBase enemy) : base(enemy) { }
    public override void EneterBexaviour() { } 
    public override void ExitBexaviour() { } 
    public override void UpdateBexaviour() { } 
    public override void LateUpdateBexaviour() { } 
    public override void FixedUpdateBexaviour()
    {
        RandomMove();
    } 
    public override void RandomMove()
    { 
        if (enemy.context.isRandomMove)
            Moving(enemy._enemyTr.forward);
        Debug.Log("RandomeMove beh");
    } 
}
