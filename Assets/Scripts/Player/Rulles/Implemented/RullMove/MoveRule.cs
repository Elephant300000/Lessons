using Character.Context;
using Player.PlayerStates.Base;
using Player.PlayerStates.StateHandler;

namespace Character.Rull
{
    public class MoveRule : MoveRullBase
    {
        public MoveRule(IPlayerStateHandler fsm) : base(fsm) { }
         
        public override bool CanExecute(IMoveContext ctx) => ctx.isMove & !ctx.isJump; 
        public override void Execute(IMoveContext ctx)
        { 
            ctx.SetMoveType(MoveStateType.Move);
            ctx.InvokeAction();
        }
    }
}