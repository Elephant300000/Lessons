using Player.PlayerStates.Base;


namespace Character.Context
{
    public interface IStateMoveContext : IContextBase
    {
        MoveStateType currentMoveType { get;}
        bool isIdle { get;}
        bool isWalking { get; }
        bool isRunning { get; }
        bool isSprinting { get; }
        bool isJump { get; } 
    }
}