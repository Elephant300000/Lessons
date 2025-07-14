
using Character.Context;
using Character.Rull;


namespace Character.Planer
{
    public interface IPlaner 
    {
        void AddRull(IRull<IContextBase> rull);

        void RunNextRull(IContextBase ctx);
    }

}
