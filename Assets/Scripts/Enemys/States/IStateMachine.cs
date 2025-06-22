using State;
using State.EnemyState;
using System;

public interface IStateMachine
{
    void AddTransition(EnemyStateType type, Func<EnemyStateType> transition);
    void FixedUpdateState();
    void LateUpdateState();
    void RegisteringState(EnemyStateType type, IStateGame state);
    void SetState(EnemyStateType type);
    void TryTransition();
    void UpdateState();
}