
using Character.Context;
using Character.Rull;


namespace Character.Planer
{
    public interface IPlaner<T> where T : IContextBase
    {
        void Initialize(T ctx);
        void Dispose(T ctx);
        void RegisterRule(IRullBase<T> rull); 
        void RunNextRull(T ctx);
    }

}
