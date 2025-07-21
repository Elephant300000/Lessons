using Character.Context;
using Character.Planer;
using Character.Rull;
using Enemy.Action_;
using Enemy.Context;
using Player;
using Player.PlayerBehaviours.Handler;
using Player.PlayerStates.StateHandler;
using Player.PlayerStates.States;
using State.EnemyState;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class MainUpdate : MonoBehaviour
{
    private Dictionary<EnemyBase, IStateMachine> _enemyStateMachines = new(); 
    private Dictionary<EnemyBase, IBehaviourHandler> _behaviourHandlers = new();
    private Dictionary<EnemyBase, PlanerMove> enemyPlaners = new();
    private List<EnemyBase> _enemies = new();

    private PlayerFSM fsm = new();
    private PlayerBehaviourHandler playerbehaviourHandler = new PlayerBehaviourHandler();
    public MoveContext MoveContext = new();
    private MovePlaner movePlaner = new();
    public PlayerInfo playerInfo;
    private void Awake()
    {
        
        fsm.RegisteringState(Player.PlayerStates.Base.MoveStateType.Move, new Move(fsm,playerbehaviourHandler,playerInfo));
        fsm.RegisteringState(Player.PlayerStates.Base.MoveStateType.Jump, new Jump(fsm,playerbehaviourHandler,playerInfo));
        fsm.RegisteringState(Player.PlayerStates.Base.MoveStateType.Idle, new Idle(fsm,playerbehaviourHandler,playerInfo));
        fsm.SetState(Player.PlayerStates.Base.MoveStateType.Idle);
        movePlaner.AddRule(new MoveRule(fsm));
        movePlaner.AddRule(new IdleRule(fsm));
        movePlaner.AddRule(new JumpRule(fsm));
        _enemies.AddRange(FindObjectsOfType<EnemyBase>());
    }

    private void OnDisable()
    {
        movePlaner.Exit(MoveContext);
        foreach (var enemy in _enemies)
            enemyPlaners[enemy].OnDisable(enemy.context);
    }
    private void OnEnable()
    {
        movePlaner.Enter(MoveContext);
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
        fsm.UpdateState();
        movePlaner.RunNextRull(MoveContext);

        foreach (IStateMachine stateMachine in _enemyStateMachines.Values)
            stateMachine.UpdateState();
        foreach (EnemyBase enemy in _enemies)
            enemyPlaners[enemy].UpdateContext(enemy.context);
    }
    private void LateUpdate()
    {
        fsm.LateUpdateState();
        foreach (IStateMachine stateMachine in _enemyStateMachines.Values)
            stateMachine.LateUpdateState();
    }
    private void FixedUpdate()
    {
        fsm.FixedUpdateState();
        foreach (IStateMachine stateMachine in _enemyStateMachines.Values)
            stateMachine.FixedUpdateState();

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


    private void InitializeBehaviours(EnemyBase enemy, IBehaviourHandler behaviourHandler /*, PlayerBehaviourHandler pl*/)
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