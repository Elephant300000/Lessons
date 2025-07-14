using Player.PlayerInterfases;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace Player.PlayerBehaviours.Base
{
    public abstract class BehavioursBase : 
       IPlayerIdel,
       IPlayerMove,
       IPlayerRun,
       IWeaponHolder,
       IBehaviourBase 
    {
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