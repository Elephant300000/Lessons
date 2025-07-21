using Character.Context;
using Character.Planer;
using Player.PlayerBehaviours.Behaviours;
using Player.PlayerInterfases;
using Player.PlayerStates.StateHandler;
using Player.PlayerStates.States;
using Player.PlayerStates.Base;
using Character.Rull;
public class MainCharacter  
{
    public MainCharacter(

       PlayerInfo charac, 
       IBehaviourHandler behaviourHandler,
       IMoveContext contextMove )
    {

        this.character = charac; 
        this.behaviourHandler = behaviourHandler;
        this.contextMove = contextMove;

        planer = new Character.Planer.PlanerMove();
        moveFSM = new PlayerFSM(); 
    }

    private PlayerInfo character; 

    private IBehaviourHandler behaviourHandler;
    private IMoveContext contextMove; 
    private IPlaner<IMoveContext> planer;  
    private IStateHandler moveFSM; 

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
        planer.AddRule(new IdleRule(moveFSM));
        //planer.AddRule(new WalkRule(moveFSM));// где этот класс 
        planer.AddRule(new RunRule(moveFSM));
        //planer.AddRule(new SprintRule(moveFSM));// где этот класс
    }
    private void InitializeBehaviours()
    {
        behaviourHandler.RegisterBehaviour<IIdleBehaviourPlayer>(new IdelBehaviourPlayer(character));
        //behaviourHandler.RegisterBehaviour<IWalkBehaviour>(new WalckBehaviourPlayer(character));// где этот Interface ???
        behaviourHandler.RegisterBehaviour<IRunBehaviourPlayer>(new RunBehaviourPlayer(character));// где этот класс
        //behaviourHandler.RegisterBehaviour<ISprintBehaviour>(new SprintBehaviourPlayer(character));// где этот класс и Interface ???
       // behaviourHandler.RegisterBehaviour<IJumpBehaviour>(new JumpBehaviourPlayer(characterMove));// где этот Interface ???

        //behaviourHandler.RegisterBehaviour<IMoveBehaviourPlayer>(new MoveBehaviourPlayer(character));// где этот класс  
        //behaviourHandler.RegisterBehaviour<IRotateBehaviour>(new RotateBehaviourPlayer(character));// где этот класс

    }

    private void InitializeStates()
    {
        moveFSM.RegisteringState(MoveStateType.Idle, new IdleStatePlayer(behaviourHandler, character));
       // moveFSM.RegisteringState(MoveStateType.Walking, new WalkStatePlayer(behaviourHandler, character)); // где этот класс - WalkStatePlayer ???
       // moveFSM.RegisteringState(MoveStateType.Running, new RunStatePlayer(behaviourHandler, character));// где этот класс - RunStatePlayer ??
       // moveFSM.RegisteringState(MoveStateType.Sprinting, new SprintStatePlayer(behaviourHandler, character));// где этот класс - SprintStatePlayer ??
        moveFSM.SetState(MoveStateType.Idle);
    }
    public void FixedTick()
    {
        moveFSM.FixedUpdateState(); 
    }

    public void LateTick()
    {
        moveFSM.LateUpdateState(); 
    }

    public void Tick()
    {
        planer?.RunNextRull(contextMove); 
          
        moveFSM.UpdateState(); 
    }

}
