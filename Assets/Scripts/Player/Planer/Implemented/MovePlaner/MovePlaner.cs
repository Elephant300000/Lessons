
using Character.Context;
using Character.Rull;
using System.Collections.Generic;


namespace Character.Planer
{
    public class MovePlaner : IMovePlaner
    {
        private readonly List<IRullBase<IMoveContext>> rulless = new();
       
        public void AddRule(IRullBase<IMoveContext> rull)// coll from Main
        {
            rulless.Add(rull);
        }

        public void Enter(IMoveContext ctx) // coll from Main
        {
            foreach (var rull in rulless)
                rull.Subscrube(ctx);
        }

        public void Exit(IMoveContext ctx)// coll from Main
        {
            foreach (var rull in rulless)
                rull.Unubscrube(ctx);
        }

        public void RunNextRull(IMoveContext ctx)// coll from Main
        {
            foreach (var rull in rulless)
            {
                if (rull.CanExecute(ctx))
                {
                    rull.Execute(ctx);
                }
            }
        }
    }
}