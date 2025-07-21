using Character.Context;
using Player.PlayerStates.Base;
using Player.PlayerStates.StateHandler;

namespace Character.Rull
{
    public  class JumpRule : MoveRullBase
    {
        public JumpRule(IStateHandler fsm) : base(fsm) { }

        public override bool CanExecute(IMoveContext ctx) => ctx.isJump;
        public override void Execute(IMoveContext ctx)
        {
            ctx.SetMoveType(MoveStateType.Jump);
            ctx.InvokeAction();
        }
    }
}