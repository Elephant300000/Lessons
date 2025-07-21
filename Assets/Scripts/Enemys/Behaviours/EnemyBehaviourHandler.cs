using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyBehaviourHandler : IBehaviourHandler
{
    private readonly Dictionary<Type, IBehaviourBase> bexaviours = new();

    T IBehaviourHandler.GetBehaviour<T>()
    {
        return bexaviours.TryGetValue(typeof(T), out var behaviour) ? behaviour as T : null;
    }

    void IBehaviourHandler.RegisterBehaviour<T>(T behaviour)   
    {
        if (behaviour == null || bexaviours.ContainsKey(typeof(T))) return;
        bexaviours.Add(typeof(T),behaviour);
    }
}
