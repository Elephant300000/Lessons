using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.PlayerBehaviours.Base;

namespace Player.PlayerBehaviours.Behaviours
{
    public class ShootBeh : BehaviourPlayerBase
    {
        public ShootBeh(PlayerInfo playerInfo) : base(playerInfo)
        {
        }

        public override void EneterBexaviour()
        {
        }

        public override void ExitBexaviour()
        {
        }

        public override void FixedUpdateBehaviour()
        {
            Shot();
        }

        public override void LateUpdateBexaviour()
        {
        }

        public override void UpdateBexaviour()
        {
        }

        public override void Shot()
        {
            Debug.Log("Shoot");

        }
    }
}