using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMove : IBehaviourBase
{
    void Moving(Vector3 _dierectionOfRotate);
}
