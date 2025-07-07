using Player.PlayerBehaviours.Behaviours;
using Player.PlayerStates.Base;
using Player.PlayerStates.StateHandler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player.PlayerStates.States
{
    public class Move : PlayerStateBase
    {
        public Move(

       IPlayerStateHandler _stateHandler,
       IBehaviourHandler behaviourHandler,
       PlayerBase pl
       ) : base(_stateHandler, behaviourHandler, pl)
        {
            behaviours = new List<IBehaviourBase>()
        {
            behaviourHandler.GetBehaviour<RunBeh>(),
            behaviourHandler.GetBehaviour<ShootBeh>(),
            behaviourHandler.GetBehaviour<WalckBeh>(),

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
                behaviour.FixedUpdateBexaviour();
        }

       
    }
}
