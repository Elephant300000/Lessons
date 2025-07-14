using Character.Context;
using Player.PlayerStates.Base;
using Player.PlayerStates.StateHandler;

namespace Character.Rull
{
    public  class SprintRull : MoveRullBase
    {
        public SprintRull(IPlayerStateHandler fsm) : base(fsm) { }

        public override bool CanExecute(IMoveContext ctx) => ctx.isSprinting;
        public override void Execute(IMoveContext ctx)
        {
            ctx.SetMoveType(MoveStateType.Sprint);
            ctx.InvokeAction();
        }
    }
}