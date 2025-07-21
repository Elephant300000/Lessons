using Player.PlayerStates.Base;

namespace Character.Context
{
    public interface IMoveContext  :  IEventMoveContext, IStateMoveContext, IMoveCommandContext
    {
        
    } 
}
