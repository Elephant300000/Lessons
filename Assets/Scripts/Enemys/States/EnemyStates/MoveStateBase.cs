﻿using State.EnemyState;
using System.Collections.Generic;

public class MoveState : EnemyStateBase
{
    public MoveState(

        IStateMachine _stateHandler, 
        IBehaviourHandler behaviourHandler, 
        EnemyBase enemy) : base(_stateHandler, behaviourHandler, enemy)
    {
        Transitions();
        behaviours = new List<IBehaviourBase>()
        {
            behaviourHandler.GetBehaviour<IRandomMoveBehaviour>(),
            behaviourHandler.GetBehaviour<IRandomRotateBehaviour>()
        };
    }

    public override void EnterState()
    {
        foreach (var behaviour in behaviours)
            behaviour.EneterBexaviour();
    }

    public override void ExitState()
    {
        foreach (var behaviour in behaviours)
            behaviour.ExitBexaviour();
    }

    public override void UpdateState()
    {
        foreach (var behaviour in behaviours)
            behaviour.UpdateBexaviour();
    }
    public override void LateUpdateState()
    {
        foreach (var behaviour in behaviours)
            behaviour.LateUpdateBexaviour();
    }

    public override void FixedUpdateState()
    {
        foreach (var behaviour in behaviours)
            behaviour.FixedUpdateBexaviour();
    }
    private void Transitions()
    {
        var type = EnemyStateType.Move;
        _stateHandler.AddTransition(type, () => !_enemy.isRandomMove ? EnemyStateType.Idel : type);
        _stateHandler.AddTransition(type, () => _enemy.isIdle ? EnemyStateType.Idel : type);
        _stateHandler.AddTransition(type, () => _enemy.isFollowTarget ? EnemyStateType.Follow : type);
    }
}