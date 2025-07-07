using System;

namespace Enemy.Context
{
    public interface IContextEvent
    {
        event Action onTryTransitionState;
        void UpdateContext();
    }
    public interface IContextBase:IContextEvent,IContextCommands,IContextStates
    {

    }
    public interface IContextStates
    {
        bool IsFollow { get; }
    }
    public interface IContextCommands
    {
        void SetIsFollow(bool isFollow);
    }
    public class TestContext : IContextBase
    {
        private bool _isFollow = false;
        public bool IsFollow => _isFollow;

        public event Action onTryTransitionState;

        public void SetIsFollow(bool _isFollow)
        {
            if (IsFollow == _isFollow) return;
            this._isFollow = _isFollow;
            onTryTransitionState?.Invoke();
        }


        public void UpdateContext()
        {
            throw new NotImplementedException();
        }
    }
}