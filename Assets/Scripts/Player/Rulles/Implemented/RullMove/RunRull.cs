using Character.Context;
using Player.PlayerStates.Base;
using Player.PlayerStates.StateHandler;

namespace Character.Rull
{
    public class RunRull : MoveRullBase
    {
        public RunRull(IPlayerStateHandler fsm) : base(fsm) { }
         
        public override bool CanExecute(IMoveContext ctx) => ctx.isRunning; 
        public override void Execute(IMoveContext ctx)
        { 
            ctx.SetMoveType(MoveStateType.Run);
            ctx.InvokeAction();
        }
    }
}