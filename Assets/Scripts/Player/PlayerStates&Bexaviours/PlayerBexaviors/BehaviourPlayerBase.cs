using Player.PlayerInterfases;
using UnityEngine.InputSystem;


namespace Player.PlayerBehaviours.Base
{
    public abstract class BehaviourPlayerBase : 
       IIdleBehaviourPlayer,
       IMoveBehaviourPlayer,
       IRunBehaviourPlayer,
       IWeaponHolder,
       IBehaviourBase 
    {
        public BehaviourPlayerBase(PlayerInfo playerInfo)
        {
            this.playerInfo = playerInfo;
        }
        protected readonly PlayerInfo playerInfo;

        public abstract void EneterBexaviour();
        public abstract void ExitBexaviour();
        public abstract void FixedUpdateBehaviour();
        public virtual void Idel() { }
        public virtual void InputMove(InputAction.CallbackContext ctx) { }
        public virtual void Jump() { }
        public abstract void LateUpdateBexaviour();
        public virtual void Run(InputAction.CallbackContext ctx) { }
        public abstract void UpdateBexaviour();
        public virtual void Shot() { }
       
    }
}