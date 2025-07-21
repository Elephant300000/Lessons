using Player.PlayerStates.Base;


namespace Character.Context 
{
    public interface IMoveCommandContext  : IContextBase
    { 
        void SetIdle(bool isIdle);
        void SetJump(bool isJump);
        void SetMove(bool isMove);
        void SetMoveType(MoveStateType moveStateType);
        /// добавить Setrun Setsprint Setwalk
    }
}