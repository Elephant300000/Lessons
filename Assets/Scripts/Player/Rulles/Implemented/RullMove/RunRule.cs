using Character.Context;
using Player.PlayerStates.Base;
using Player.PlayerStates.StateHandler;

namespace Character.Rull
{
    public class RunRule : MoveRullBase
    {
        public RunRule(IStateHandler fsm) : base(fsm) { }
         
        public override bool CanExecute(IMoveContext ctx) => ctx.isMove & !ctx.isJump; 
        public override void Execute(IMoveContext ctx)
        { 
            ctx.SetMoveType(MoveStateType.Running);
            ctx.InvokeAction();
        }
    }
}