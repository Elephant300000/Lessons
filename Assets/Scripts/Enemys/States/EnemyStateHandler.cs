using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using State;
using State.EnemyState;

public class EnemyStateHandler : IStateHandler
{
    private IStateGame _currentState;
    private EnemyStateType _currentStateType;
    private Dictionary<EnemyStateType, IStateGame> States = new();
    private Dictionary<EnemyStateType, List<Func<EnemyStateType>>> Transitions = new();
    public void SetState(EnemyStateType type)
    {
        if (States.ContainsKey(type)) 
        {
            _currentState?.ExitState();
            _currentState = States[type];
            _currentStateType = type;
            _currentState?.EnterState();
        }
        
    }
    public void RegistorStates(EnemyStateType type, IStateGame state)
    {
        if (!States.ContainsKey(type))
            States[type] = state;
    }
    public void AddTransition(EnemyStateType type, Func<EnemyStateType> transition)
    {
        if (!Transitions.ContainsKey(type))
        {
            Transitions[type] = new List<Func<EnemyStateType>>();
                        
        }
        Transitions[type].Add(transition);
    }

    public void UpdateState()
    {
        TryTransition();
        _currentState?.UpdateState();
    }
    public void LateUpdateState()
    {
        _currentState?.LateUpdateState();
    }
    public void FixedUpdateState()
    {
        _currentState?.FixedUpdateState();
    }

    public void TryTransition()
    {
        if (Transitions.TryGetValue(_currentStateType, out List<Func<EnemyStateType>> transitions))
        {
            foreach (var eventf in transitions)
            {
                var stateType = eventf.Invoke();
                if (stateType.Equals(_currentStateType))
                {
                    SetState(stateType);
                }
            }
        }
    }
}
public interface IStateHandler
{

    void SetState(EnemyStateType type);
    void UpdateState();
    void FixedUpdateState();
    void LateUpdateState();
    void AddTransition(EnemyStateType type, Func<EnemyStateType> transition);
    void TryTransition();
    void RegistorStates(EnemyStateType type, IStateGame state);
}


