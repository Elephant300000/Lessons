using UnityEngine;

public class LookTargetBehaviour : RotateBehaviour
{
    public LookTargetBehaviour(EnemyBase enemy) : base(enemy) { }
    public override void EneterBexaviour() { }
    public override void ExitBexaviour() { }
    public override void UpdateBexaviour() { }
    public override void LateUpdateBexaviour() { }
    public override void FixedUpdateBexaviour()
    {
        LookRotate();
    }
    public override void LookRotate()
    {  
        Vector3 dierection = enemy._playerTr.position - enemy._enemyTr.position;
        dierection.y = 0;
        Quaternion rotate = Quaternion.LookRotation(dierection);
        Rotate(rotate);
        Debug.Log("LookTarget beh");
    }  
}
