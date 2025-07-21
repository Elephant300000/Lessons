using Player.PlayerBehaviours.Behaviours;
using Player.PlayerStates.Base;
using System.Collections.Generic;


namespace Player.PlayerStates.States
{
    public class IdleStatePlayer : PlayerStateBase
    {
        public IdleStatePlayer(IBehaviourHandler behaviourHandler) : base(behaviourHandler)
        {

            behaviours = new List<IBehaviourBase>()
            {
                behaviourHandler.GetBehaviour<IdelBehaviourPlayer>()
               //jump, rotate 
            };
        }

        public override void EnterState()
        {
            foreach (var behaviour in behaviours)
                behaviour.EneterBexaviour();
        }

        public override void ExitState()
        {
            foreach (var behaviour in behaviours)
                behaviour.ExitBexaviour();
        }

        public override void UpdateState()
        {
            foreach (var behaviour in behaviours)
                behaviour.UpdateBexaviour();
        }
        public override void LateUpdateState()
        {
            foreach (var behaviour in behaviours)
                behaviour.LateUpdateBexaviour();
        }

        public override void FixedUpdateState()
        {
            foreach (var behaviour in behaviours)
                behaviour.FixedUpdateBehaviour();
        }

      
    }
}
