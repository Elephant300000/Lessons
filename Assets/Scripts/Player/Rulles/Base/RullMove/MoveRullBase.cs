using Character.Context;
using Player.PlayerStates.StateHandler;

namespace Character.Rull
{
    public abstract class MoveRullBase : IRullBase<IMoveContext>
    {
        public MoveRullBase(IStateHandler fsm)
        {
            this._fsm = fsm;
        }
        protected IStateHandler _fsm;
        public void Subscrube(IMoveContext ctx)
        {
            ctx.onChangeMoveState += _fsm.SetState;
        }

        public void Unubscrube(IMoveContext ctx)
        {
            ctx.onChangeMoveState -= _fsm.SetState;
        }
        public abstract bool CanExecute(IMoveContext ctx);

        public abstract void Execute(IMoveContext ctx); 
    }
}