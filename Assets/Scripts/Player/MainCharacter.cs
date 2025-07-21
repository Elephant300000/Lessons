using Character.Context;
using Character.Planer;
using Character.Rull;
using Player.PlayerBehaviours.Behaviours;
using Player.PlayerInterfases;
using Player.PlayerStates.Base;
using Player.PlayerStates.StateHandler;
using Player.PlayerStates.States;


public class MainCharacter  // проинициализировать в main global
{
    // context аргумент в конструткоре main не через new MoveContext
    // а через PlayerInfo.contextMove
    // new PlayerInfo
    public MainCharacter(

       PlayerInfo charac, 
       IBehaviourHandler behaviourHandler,
       IMoveContext contextMove,
       IStateHandler moveFSM,
       IPlaner<IMoveContext> planer)
    {

        this.character = charac; 
        this.behaviourHandler = behaviourHandler;
        this.contextMove = contextMove; 
        this.planer = planer;
        this.fsm = moveFSM; 
    }

    private PlayerInfo character;  
    private IBehaviourHandler behaviourHandler;
    private IMoveContext contextMove; 
    private IStateHandler fsm;
    private IPlaner<IMoveContext> planer;  


    public void Initialize()
    {
        InitializeStates();
        InitializeBehaviours();
        InitializeRules();
        planer.Initialize(contextMove); 
    }

    public void Dispose()
    {
        planer.Dispose(contextMove); 
    }
    private void InitializeRules()
    {
        //planer.RegisterRule(new IdleRule(fsm));
        //planer.RegisterRule(new WalkRule(fsm));// где этот класс 
        //planer.RegisterRule(new RunRule(fsm));
        //planer.RegisterRule(new SprintRule(fsm));// где этот класс
    }
 
    private void InitializeBehaviours()
    {
       //behaviourHandler.RegisterBehaviour<IIdleBehaviourPlayer>(new IdelBehaviourPlayer(character));
       //behaviourHandler.RegisterBehaviour<IWalkBehaviour>(new WalckBehaviourPlayer(character));// где этот Interface ???
       //behaviourHandler.RegisterBehaviour<IRunBehaviourPlayer>(new RunBehaviourPlayer(character));// где этот класс
       //behaviourHandler.RegisterBehaviour<ISprintBehaviour>(new SprintBehaviourPlayer(character));// где этот класс и Interface ???
       //behaviourHandler.RegisterBehaviour<IJumpBehaviour>(new JumpBehaviourPlayer(characterMove));// где этот Interface ???

       //behaviourHandler.RegisterBehaviour<IMoveBehaviourPlayer>(new MoveBehaviourPlayer(character));// где этот класс  
       //behaviourHandler.RegisterBehaviour<IRotateBehaviour>(new RotateBehaviourPlayer(character));// где этот класс

    }

    private void InitializeStates()
    {
       //fsm.RegisteringState(MoveStateType.Idle, new IdleStatePlayer(behaviourHandler));
       //fsm.RegisteringState(MoveStateType.Walking, new WalkStatePlayer(behaviourHandler)); // где этот класс - WalkStatePlayer ???
       //fsm.RegisteringState(MoveStateType.Running, new RunStatePlayer(behaviourHandler));// где этот класс - RunStatePlayer ??
       //fsm.RegisteringState(MoveStateType.Sprinting, new SprintStatePlayer(behaviourHandler));// где этот класс - SprintStatePlayer ??
       //fsm.SetState(MoveStateType.Idle);
    }
    public void FixedTick()
    {
        fsm.FixedUpdateState(); 
    }

    public void LateTick()
    {
        fsm.LateUpdateState(); 
    }

    public void Tick()
    {
        planer?.RunNextRull(contextMove);
        fsm.UpdateState(); 
    }

}



