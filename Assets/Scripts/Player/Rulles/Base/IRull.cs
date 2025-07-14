using Character.Context;

namespace Character.Rull
{
    public interface IRull<T> where T : IContextBase
    {
        bool CanExecute(T ctx);
        void Execute(T ctx);
    }
}

