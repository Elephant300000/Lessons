using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBehaviourHandler
{
    void Registr<T>(T behaviour) where T : class, IBehaviourBase;
    T Get<T>() where T : class, IBehaviourBase;
}
