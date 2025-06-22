using State.EnemyState;
using System.Collections.Generic;
using UnityEngine;

public class MainUpdate : MonoBehaviour
{
    private Dictionary<EnemyBase, IStateMachine> _enemyStateMachines = new(); 
    private Dictionary<EnemyBase, IBehaviourHandler> _behaviourHandlers = new();
    private List<EnemyBase> _enemyBases = new();

    private void Awake()
    {
        _enemyBases.AddRange(FindObjectsOfType<EnemyBase>());
    } 
    private void Start()
    {
        foreach (EnemyBase enemy in _enemyBases)
            StartInitializeDictionory(enemy);
    } 
    void Update()
    {
        foreach (IStateMachine stateMachine in _enemyStateMachines.Values)
            stateMachine.UpdateState();
    }
    private void LateUpdate()
    {
        foreach (IStateMachine stateMachine in _enemyStateMachines.Values)
            stateMachine.LateUpdateState();        
    }
    private void FixedUpdate()
    {
        foreach (IStateMachine stateMachine in _enemyStateMachines.Values)
            stateMachine.FixedUpdateState();
    }

    private void StartInitializeDictionory(EnemyBase enemy)
    {
        var stateMachine = new EnemyStateMachine();
        var behaviourHandler = new BehaviourHandler();

        InitializeBexaviours(enemy, behaviourHandler);
        InitializeStates(stateMachine, behaviourHandler, enemy);
        stateMachine.SetState(EnemyStateType.Idel);

        _enemyStateMachines[enemy] = stateMachine;
        _behaviourHandlers[enemy] = behaviourHandler;
    }

    private void InitializeBexaviours(EnemyBase enemy, IBehaviourHandler behaviourHandler)
    {
        behaviourHandler.RegisteringBehaviour<IIdleBehaviour>(new IdleBehaviour(enemy));

        behaviourHandler.RegisteringBehaviour<IMoveBehaviour>(new MoveBehaviour(enemy));
        behaviourHandler.RegisteringBehaviour<IRotateBehaviour>(new RotateBehaviour(enemy));

        behaviourHandler.RegisteringBehaviour<IRandomRotateBehaviour>(new RandomRotateBehaviour(enemy));
        behaviourHandler.RegisteringBehaviour<IRandomMoveBehaviour>(new RandomMoveBehaviour(enemy));

        behaviourHandler.RegisteringBehaviour<IFollowTargetBehaviour>(new FollowTargetBehaviour(enemy));
        behaviourHandler.RegisteringBehaviour<ILookTargetBehaviour>(new LookTargetBehaviour(enemy));
    }
    public void InitializeStates(IStateMachine _stateMachine, IBehaviourHandler behaviourHandler, EnemyBase enemy)
    {
        _stateMachine.RegisteringState(EnemyStateType.Idel, new IdleState(_stateMachine, behaviourHandler, enemy));
        _stateMachine.RegisteringState(EnemyStateType.Move, new MoveState(_stateMachine, behaviourHandler, enemy));
        _stateMachine.RegisteringState(EnemyStateType.Follow, new FollowTargetState(_stateMachine, behaviourHandler, enemy)); 
    }
}
