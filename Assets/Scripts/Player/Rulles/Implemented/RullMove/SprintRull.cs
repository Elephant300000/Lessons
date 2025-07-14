using Character.Context;
using Player.PlayerStates.Base;

namespace Character.Rull
{
    public class SprintRull : IRull<IMoveContext>
    {
        public bool CanExecute(IMoveContext ctx) => ctx.isSprinting;

        public void Execute(IMoveContext ctx)
        {
            ctx.SetMoveType(MoveStateType.Sprint);
            ctx.InvokeAction();
        }
    }
}