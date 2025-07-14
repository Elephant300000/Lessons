using Character.Context;
using Player.PlayerStates.Base;
using Player.PlayerStates.StateHandler;

namespace Character.Rull
{
    public class WalkRull : MoveRullBase
    {
        public WalkRull(IPlayerStateHandler fsm) : base(fsm) { }
         
        public override bool CanExecute(IMoveContext ctx) => ctx.isWalking;
         

        public override void Execute(IMoveContext ctx)
        {
            ctx.SetMoveType(MoveStateType.Walk);
            ctx.InvokeAction();
        }
    }
}