using UnityEngine;

public class RandomRotateBehaviour : RotateBehaviour
{
    public RandomRotateBehaviour(EnemyBase enemy) : base(enemy) { }
    private float _time; 
    public override void EneterBexaviour() { } 
    public override void ExitBexaviour() { } 
    public override void UpdateBexaviour() { } 
    public override void LateUpdateBexaviour() { } 
    public override void FixedUpdateBexaviour()
    { 
        RandomRotate();
    }
    public override void RandomRotate()
    {
        if (enemy.isRandomRotate)
        {
            float turnAmount = 0;
            float currentY = enemy._enemyTr.eulerAngles.y;
            if (_time <= Time.time)
            {
                _time = Time.time + Random.Range(0.5f, 1.5f);
                turnAmount = Random.Range(45, 185);
                if (Random.value > 0.5f) turnAmount *= -1;
            }  
            Rotate(Quaternion.Euler(0, currentY + turnAmount, 0));
        }
        Debug.Log("RandomRotate beh");
    }
}
