using Player.PlayerBehaviours.Behaviours;
using Player.PlayerStates.Base;
using Player.PlayerStates.StateHandler;
using State.EnemyState;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.OnScreen.OnScreenStick;
namespace Player.PlayerStates.States
{
    public class Idel : PlayerStateBase
    {
        
        public Idel(

        IPlayerStateHandler _stateHandler,
        IBehaviourHandler behaviourHandler,
        PlayerBase pl
        ) : base(_stateHandler, behaviourHandler, pl)
        {
            behaviours = new List<IBehaviourBase>()
        {
            behaviourHandler.GetBehaviour<IdelBeh>(),
            behaviourHandler.GetBehaviour<ShootBeh>(),
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
