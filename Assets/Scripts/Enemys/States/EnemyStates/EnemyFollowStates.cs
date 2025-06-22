using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State.EnemyState;
public class EnemyFollowStates : EnemyStateBase
{
    public EnemyFollowStates(IStateHandler _stateHandler, IBehaviourHandler behaviourHandler, EnemyBase enemy) : base(_stateHandler, behaviourHandler, enemy)
    {
        Transitions();
        behaviours = new List<IBehaviourBase>()
        {
            behaviourHandler.Get<IEnemyFollowTarget>(),
            behaviourHandler.Get<IEnemyLookTarget>(),
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
            behaviour.ExidBexaviour();
    }

    public override void UpdateState()
    {
        foreach (var behaviour in behaviours)
            behaviour.Update();
    }
    public override void LateUpdateState()
    {
        foreach (var behaviour in behaviours)
            behaviour.LateUpdate();
    }

    public override void FixedUpdateState()
    {
        foreach (var behaviour in behaviours)
            behaviour.FixedUpdate();
    }

    private void Transitions()
    {
        var type = EnemyStateType.Follow;
        _stateHandler.AddTransition(type, () => _enemy.IsRandomMove ? EnemyStateType.Move : type);
        _stateHandler.AddTransition(type, () => _enemy.IsIdel ? EnemyStateType.Idel : type);
    }
}

    

