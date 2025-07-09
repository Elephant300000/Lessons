using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Context;
using Enemy.Action_;
using System;

public class PlanerMove
{
    public List<IAction> actions = new List<IAction>();
    public void RegistrAction (IAction action) => actions.Add(action);
    public void OnEnable(IContextEvent ctx)
    {
        foreach (var action in actions) 
            action?.Subscribe(ctx);

    }
    public void UpdateContext(IContextEvent context)
    {
        foreach (var action in actions)
            action.Exicute(context);
    }
    public void OnDisable(IContextEvent ctx)
    {

        foreach (var action in actions)  
            action?.Unsubscribe(ctx);
    }

}
