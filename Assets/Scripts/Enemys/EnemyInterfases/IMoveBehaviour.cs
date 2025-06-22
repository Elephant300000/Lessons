using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveBehaviour : IBehaviourBase
{
    void Moving(Vector3 _dierectionOfRotate);
}
