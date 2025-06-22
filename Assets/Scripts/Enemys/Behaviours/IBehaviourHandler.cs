using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBehaviourHandler
{
    void RegisteringBehaviour<T>(T behaviour) 
        where T : class, IBehaviourBase; 

    T GetBehaviour<T>() 
        where T : class, IBehaviourBase;
     
}
