using Character.Context;

namespace Character.Rull
{
    public interface IRullBase<T> where T : IContextBase
    {
        void Subscrube(T ctx);
        void Unubscrube(T ctx);

        bool CanExecute(T ctx);
        void Execute(T ctx);
    }
}

