using Character.Context;
using Player.PlayerStates.Base;

namespace Character.Rull
{
    public class IdleRull : IRull<IMoveContext>
    {
        public IdleRull(IStateMachine fsm)
        {
            this.fsm = fsm;
        }
        IStateMachine fsm;
        //void Sub(IMoveContext ctx)
        //{
        //    ctx.onChangeState += fsm.SetState(ctx.currentStateType);
        //}
        //void UnSub(IMoveContext ctx)
        //{
        //    ctx.onChangeState = fsm.SetState(ctx.currentStateType);
        //}
        public bool CanExecute(IMoveContext ctx) => ctx.isIdle;

        public void Execute(IMoveContext ctx)
        {
            ctx.SetMoveType(MoveStateType.Idle);
            ctx.InvokeAction();
        }
    }
}