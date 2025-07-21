using Character.Context;
using Enemy.Action_;
using State.EnemyState;
using System.Collections.Generic;
using UnityEngine;

public class MainEnemyUpdate : MonoBehaviour /// // проинициализировать в main global
{
    // создвть конструктор

    private Dictionary<EnemyBase, IStateMachine> _enemyStateMachines = new(); 
    private Dictionary<EnemyBase, IBehaviourHandler> _behaviourHandlers = new();
    private Dictionary<EnemyBase, PlanerMoveEnemy> enemyPlaners = new();
    private List<EnemyBase> _enemies = new();
     
    private void Awake()
    { //в main galobal передать аргумент в конструктор
        _enemies.AddRange(FindObjectsOfType<EnemyBase>()); 
        foreach (EnemyBase enemy in _enemies)
            StartInitializeDictionory(enemy);
    }
    
    private void OnEnable()
    {
        
        foreach (var enemy in _enemies)
            enemyPlaners[enemy].OnEnable(enemy.context);
    }
    private void OnDisable()
    {
        foreach (var enemy in _enemies)
            enemyPlaners[enemy].OnDisable(enemy.context);
    }
    void Update()
    { 
        foreach (IStateMachine stateMachine in _enemyStateMachines.Values)
            stateMachine.UpdateState();
        foreach (EnemyBase enemy in _enemies)
            enemyPlaners[enemy].UpdateContext(enemy.context);
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
        var behaviourHandler = new EnemyBehaviourHandler();
        var planer = new PlanerMoveEnemy();

        InitializeBehaviours(enemy, behaviourHandler);
        InitializeStates(stateMachine, behaviourHandler, enemy);
        InitializePlaner(stateMachine, planer);
        stateMachine.SetState(EnemyStateType.Idel);

        _enemyStateMachines[enemy] = stateMachine;
        _behaviourHandlers[enemy] = behaviourHandler;
        enemyPlaners[enemy] = planer;
    }
    private void InitializeBehaviours(EnemyBase enemy, IBehaviourHandler behaviourHandler /*, PlayerBehaviourHandler pl*/)
    {
        behaviourHandler.RegisterBehaviour<IIdleBehaviour>(new IdleBehaviour(enemy));

        behaviourHandler.RegisterBehaviour<IMoveBehaviour>(new MoveBehaviour(enemy));
        behaviourHandler.RegisterBehaviour<IRotateBehaviour>(new RotateBehaviour(enemy));

        behaviourHandler.RegisterBehaviour<IRandomRotateBehaviour>(new RandomRotateBehaviour(enemy));
        behaviourHandler.RegisterBehaviour<IRandomMoveBehaviour>(new RandomMoveBehaviour(enemy));

        behaviourHandler.RegisterBehaviour<IFollowTargetBehaviour>(new FollowTargetBehaviour(enemy));
        behaviourHandler.RegisterBehaviour<ILookTargetBehaviour>(new LookTargetBehaviour(enemy));
        
        
    }
    public void InitializeStates(IStateMachine _stateMachine, IBehaviourHandler behaviourHandler, EnemyBase enemy)
    {
        _stateMachine.RegisteringState(EnemyStateType.Idel, new IdleState(_stateMachine, behaviourHandler, enemy));
        _stateMachine.RegisteringState(EnemyStateType.Move, new MoveState(_stateMachine, behaviourHandler, enemy));
        _stateMachine.RegisteringState(EnemyStateType.Follow, new FollowTargetState(_stateMachine, behaviourHandler, enemy)); 
    }
    public void InitializePlaner(IStateMachine _stateMachine, PlanerMoveEnemy planerMove)
    {
        planerMove.RegistrAction(new ActionMove(_stateMachine));
    }
}