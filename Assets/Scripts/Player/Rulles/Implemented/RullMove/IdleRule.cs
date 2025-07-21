using Character.Context;
using Player.PlayerStates.Base;
using Player.PlayerStates.StateHandler;

namespace Character.Rull
{
    public class IdleRule : MoveRullBase 
    {
        public IdleRule(IStateHandler fsm) : base(fsm) { }

        public override bool CanExecute(IMoveContext ctx) => ctx.isIdle& !ctx.isJump;

        public override void Execute(IMoveContext ctx)
        {
            ctx.SetMoveType(MoveStateType.Idle);
            ctx.InvokeAction();
        }
    }
}