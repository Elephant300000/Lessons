using State.EnemyState;
using System.Collections.Generic;

public class IdleState : EnemyStateBase
{
    public IdleState(

        IStateMachine _stateHandler,
        IBehaviourHandler behaviourHandler,
        EnemyBase enemy) : base(_stateHandler, behaviourHandler, enemy)
    {
        Transitions();
        behaviours = new List<IBehaviourBase>()
        {
            behaviourHandler.GetBehaviour<IIdleBehaviour>(),
            behaviourHandler.GetBehaviour<ILookTargetBehaviour>(),
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
        var type = EnemyStateType.Idel;
        _stateHandler.AddTransition(type, () => !_enemy.isIdle ? EnemyStateType.Move : type);
        _stateHandler.AddTransition(type, () => _enemy.isRandomMove ? EnemyStateType.Move : type);
        _stateHandler.AddTransition(type, () => _enemy.isFollowTarget ? EnemyStateType.Follow : type);
    }
}
