using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Player.PlayerBehaviours.Handler
{
    public class BehaviourHandler : IBehaviourHandler
    {
        private readonly Dictionary<Type, IBehaviourBase> bexaviours = new();

        T IBehaviourHandler.GetBehaviour<T>()
        {
            return bexaviours.TryGetValue(typeof(T), out var behaviour) ? behaviour as T : null;
        }

        void IBehaviourHandler.RegisteringBehaviour<T>(T behaviour)
        {
            if (behaviour == null || bexaviours.ContainsKey(typeof(T))) return;
            bexaviours.Add(typeof(T), behaviour);
        }
    }
    public interface IBehaviourHandler
    {
        void RegisteringBehaviour<T>(T behaviour)
            where T : class, IBehaviourBase;

        T GetBehaviour<T>()
            where T : class, IBehaviourBase;

    }
}