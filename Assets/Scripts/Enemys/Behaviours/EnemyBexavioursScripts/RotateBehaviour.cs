using UnityEngine;

public class RotateBehaviour : EnemyBehaviourBase
{
    public RotateBehaviour(EnemyBase enemy) : base(enemy) { }
    public override void EneterBexaviour() { }
    public override void ExitBexaviour() { }
    public override void UpdateBexaviour() { }
    public override void LateUpdateBexaviour() { }
    public override void FixedUpdateBexaviour() { }
    public override void Rotate(Quaternion quaternion)
    {
        Quaternion lerpRotate = Quaternion.Slerp(enemy._enemyTr.rotation, quaternion, enemy._speedOfRotate * Time.fixedDeltaTime);
        enemy._myRb.MoveRotation(lerpRotate);
        Debug.Log("Rotate");
    } 
}
