
using Character.Context;
using Character.Rull;
using System.Collections.Generic;


namespace Character.Planer
{
    public class MovePlaner : IMovePlaner
    {
        private readonly List<IRull<IContextBase>> ruless = new List<IRull<IContextBase>>();
        public void AddRull(IRull<IContextBase> rull)
        {
            ruless.Add(rull);
        }

        public void RunNextRull(IContextBase ctx)
        {
            foreach (var rull in ruless)
            {
                if (rull.CanExecute(ctx))
                {
                    rull.Execute(ctx);
                }
            }
        }
    }
}