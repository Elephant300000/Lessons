using UnityEngine;

public class MoveBehaviour : EnemyBehaviourBase
{ 
    public MoveBehaviour(EnemyBase enemy) : base(enemy) { }
    public override void EneterBexaviour() { } 
    public override void ExitBexaviour() { } 
    public override void UpdateBexaviour() { } 
    public override void LateUpdateBexaviour() { } 
    public override void FixedUpdateBehaviour() { }
    public override void Moving(Vector3 _dierectionOfMove)
    { 
        enemy._myRb.MovePosition(enemy._myRb.position + _dierectionOfMove * enemy._speedOfMove * Time.fixedDeltaTime);
        Debug.Log("Move");
    }
}
