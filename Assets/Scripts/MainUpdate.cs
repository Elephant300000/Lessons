using Enemy.Action_;
using State.EnemyState;
using System.Collections.Generic;
using UnityEngine;

public class MainUpdate : MonoBehaviour
{
    private Dictionary<EnemyBase, IStateMachine> _enemyStateMachines = new(); 
    private Dictionary<EnemyBase, IBehaviourHandler> _behaviourHandlers = new();
    private Dictionary<EnemyBase, PlanerMove> enemyPlaners = new();
    private List<EnemyBase> _enemies = new();

    private PlayerInfo player;

    private void Awake()
    {
        _enemies.AddRange(FindObjectsOfType<EnemyBase>());
        player = FindObjectOfType<PlayerInfo>().GetComponent<PlayerInfo>();
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
            enemyPlaners[enemy].OnDisable(enemy.context);
    }

    private void Start()
    {
        foreach (EnemyBase enemy in _enemies)
            StartInitializeDictionory(enemy);
        foreach (var enemy in _enemies)
            enemyPlaners[enemy].OnEnable(enemy.context);
    } 
    void Update()
    {
        foreach (IStateMachine stateMachine in _enemyStateMachines.Values)
            stateMachine.UpdateState();
        foreach (EnemyBase enemy in _enemies)
            enemyPlaners[enemy].UpdateContext(enemy.context);

        player._stateHandler.UpdateState();


    }
    private void LateUpdate()
    {
        foreach (IStateMachine stateMachine in _enemyStateMachines.Values)
            stateMachine.LateUpdateState();
        player._stateHandler.LateUpdateState();
    }
    private void FixedUpdate()
    {
        foreach (IStateMachine stateMachine in _enemyStateMachines.Values)
            stateMachine.FixedUpdateState();
        player._stateHandler.FixedUpdateState();
    }

    private void StartInitializeDictionory(EnemyBase enemy)
    {
        var stateMachine = new EnemyStateMachine();
        var behaviourHandler = new BehaviourHandler();
        var planer = new PlanerMove();

        InitializeBehaviours(enemy, behaviourHandler);
        InitializeStates(stateMachine, behaviourHandler, enemy);
        InitializePlaner(stateMachine, planer);
        stateMachine.SetState(EnemyStateType.Idel);

        _enemyStateMachines[enemy] = stateMachine;
        _behaviourHandlers[enemy] = behaviourHandler;
        enemyPlaners[enemy] = planer;
    }


    private void InitializeBehaviours(EnemyBase enemy, IBehaviourHandler behaviourHandler)
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
    public void InitializePlaner(IStateMachine _stateMachine, PlanerMove planerMove)
    {
        planerMove.RegistrAction(new ActionMove(_stateMachine));
    }
}