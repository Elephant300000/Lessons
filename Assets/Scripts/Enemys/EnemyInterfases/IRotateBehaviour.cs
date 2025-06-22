using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRotateBehaviour : IBehaviourBase
{
    public void Rotate(Quaternion quaternion);
}
