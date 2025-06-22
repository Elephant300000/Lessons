using State;
using State.EnemyState;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyStateMachine : IStateMachine
{
    private IStateGame _currentState;
    private EnemyStateType _currentStateType;
    private readonly Dictionary<EnemyStateType, IStateGame> states = new();
    private readonly Dictionary<EnemyStateType, List<Func<EnemyStateType>>> transitions = new();
    public void  SetState(EnemyStateType type)
    {
        if (states.ContainsKey(type))
        {
            _currentState?.ExitState();
            _currentState = states[type];
            _currentStateType = type;
            _currentState?.EnterState();
        }
    }
    void IStateMachine.UpdateState()
    {
        TryTransition();
        _currentState?.UpdateState();
    }
    void IStateMachine.LateUpdateState()
    {
        _currentState?.LateUpdateState();
    }
    void IStateMachine.FixedUpdateState()
    {
        _currentState?.FixedUpdateState();
    }
     
    void IStateMachine.RegisteringState(EnemyStateType type, IStateGame state)
    {
        if (!states.ContainsKey(type))
            states[type] = state;
    }
    void IStateMachine.AddTransition(EnemyStateType type, Func<EnemyStateType> transition)
    {
        if (!transitions.ContainsKey(type))
        {
            transitions[type] = new List<Func<EnemyStateType>>();

        }
        transitions[type].Add(transition);
    }
    public void TryTransition()
    {
        if (transitions.TryGetValue(_currentStateType, out List<Func<EnemyStateType>> actions))
        {
            foreach (var action in actions)
            {
                var stateType = action.Invoke();
                if (!EqualityComparer<EnemyStateType>.Default.Equals(stateType,_currentStateType))
                {
                    SetState(stateType);
                    break;
                }
            }
        }
    }   
}



