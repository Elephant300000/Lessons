using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyRotate : IBehaviourBase
{
    public void Rotate(Quaternion quaternion);
}
