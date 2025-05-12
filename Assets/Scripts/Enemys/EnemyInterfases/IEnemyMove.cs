using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMove : IBexaviourHandler
{
    void Moving(Vector3 _dierectionOfRotate);
}
