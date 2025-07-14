using Character.Context;
using Player.PlayerStates.StateHandler;

namespace Character.Rull
{
    public abstract class MoveRullBase : IRullBase<IMoveContext>
    {
        public MoveRullBase(IPlayerStateHandler fsm)
        {
            this.fsm = fsm;
        }
        IPlayerStateHandler fsm;
        public void Subscrube(IMoveContext ctx)
        {
            ctx.onChangeMoveState += fsm.SetState;
        }

        public void Unubscrube(IMoveContext ctx)
        {
            ctx.onChangeMoveState -= fsm.SetState;
        }
        public abstract bool CanExecute(IMoveContext ctx);

        public abstract void Execute(IMoveContext ctx); 
    }
}