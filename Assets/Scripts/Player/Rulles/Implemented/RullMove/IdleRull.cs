using Character.Context;
using Player.PlayerStates.Base;
using Player.PlayerStates.StateHandler;

namespace Character.Rull
{
    public class IdleRull : MoveRullBase 
    {
        public IdleRull(IPlayerStateHandler fsm) : base(fsm) { }

        public override bool CanExecute(IMoveContext ctx) => ctx.isIdle;

        public override void Execute(IMoveContext ctx)
        {
            ctx.SetMoveType(MoveStateType.Idle);
            ctx.InvokeAction();
        }
    }
}