using System;

namespace Enemy.Context
{
    public interface IContextEvent
    {
        event Action onTryTransitionState;
        void UpdateContext();
    }
    public interface IContextBase : IContextEvent, IContextCommands, IContextStates { }



    public interface IContextStates
    {
        bool isFollowTarget { get; }
        bool isLookTarget { get; }
        bool isRandomRotate { get; }
        bool isRandomMove { get; }
        bool isIdle { get; }
    }
    public interface IContextCommands
    {
        void SetIsFollow(bool _isFollow);
        void SetIsLook(bool _isLook);
        void SetIsRanMove(bool _isRanMove);
        void SetIsRanRotate(bool _isRanRotate);
        void SetIsIdle(bool _isIdle);

    }
    
}