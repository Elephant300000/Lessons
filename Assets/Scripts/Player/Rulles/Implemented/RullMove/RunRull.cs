using Character.Context;
using Player.PlayerStates.Base;

namespace Character.Rull
{
    public class RunRull : IRull<IMoveContext> 
    {
        public bool CanExecute(IMoveContext ctx) => ctx.isRunning;

        public void Execute(IMoveContext ctx)
        {
            ctx.SetMoveType(MoveStateType.Run);
            ctx.InvokeAction(); 
        }
    }
}