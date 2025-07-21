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
        //planer.AddRule(new WalkRule(moveFSM));// ��� ���� ����� 
        planer.AddRule(new RunRule(moveFSM));
        //planer.AddRule(new SprintRule(moveFSM));// ��� ���� �����
    }
    private void InitializeBehaviours()
    {
        behaviourHandler.RegisterBehaviour<IIdleBehaviourPlayer>(new IdelBehaviourPlayer(character));
        //behaviourHandler.RegisterBehaviour<IWalkBehaviour>(new WalckBehaviourPlayer(character));// ��� ���� Interface ???
        behaviourHandler.RegisterBehaviour<IRunBehaviourPlayer>(new RunBehaviourPlayer(character));// ��� ���� �����
        //behaviourHandler.RegisterBehaviour<ISprintBehaviour>(new SprintBehaviourPlayer(character));// ��� ���� ����� � Interface ???
       // behaviourHandler.RegisterBehaviour<IJumpBehaviour>(new JumpBehaviourPlayer(characterMove));// ��� ���� Interface ???

        //behaviourHandler.RegisterBehaviour<IMoveBehaviourPlayer>(new MoveBehaviourPlayer(character));// ��� ���� �����  
        //behaviourHandler.RegisterBehaviour<IRotateBehaviour>(new RotateBehaviourPlayer(character));// ��� ���� �����

    }

    private void InitializeStates()
    {
        moveFSM.RegisteringState(MoveStateType.Idle, new IdleStatePlayer(behaviourHandler, character));
       // moveFSM.RegisteringState(MoveStateType.Walking, new WalkStatePlayer(behaviourHandler, character)); // ��� ���� ����� - WalkStatePlayer ???
       // moveFSM.RegisteringState(MoveStateType.Running, new RunStatePlayer(behaviourHandler, character));// ��� ���� ����� - RunStatePlayer ??
       // moveFSM.RegisteringState(MoveStateType.Sprinting, new SprintStatePlayer(behaviourHandler, character));// ��� ���� ����� - SprintStatePlayer ??
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
