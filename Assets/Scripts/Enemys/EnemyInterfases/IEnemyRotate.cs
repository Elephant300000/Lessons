using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyRotate : IBexaviourHandler
{
    public void Rotate(Quaternion quaternion);
}
