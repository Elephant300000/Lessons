using Character.Context;
using Player.PlayerStates.Base;

namespace Character.Rull
{
    public class WalkRull : IRull<IMoveContext>
    {
        public bool CanExecute(IMoveContext ctx) => ctx.isWalking;

        public void Execute(IMoveContext ctx)
        {
            ctx.SetMoveType(MoveStateType.Walk);
            ctx.InvokeAction();
        }
    }
}