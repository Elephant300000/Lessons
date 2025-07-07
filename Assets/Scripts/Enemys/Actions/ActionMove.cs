using Enemy.Context;

namespace Enemy.Action_
{
    public class ActionMove : IAction
    {
        public ActionMove(IStateMachine fSM)
        {
            FSM = fSM;
        }

        public IStateMachine FSM { get; set; }

        public void Exicute(IContextEvent context)
        {
            context.UpdateContext();
        }

        public void Subscribe(IContextEvent context)
        {
            context.onTryTransitionState += FSM.TryTransition;

        }

        public void Unsubscribe(IContextEvent context)
        {
            context.onTryTransitionState -= FSM.TryTransition;
        }
    }
}