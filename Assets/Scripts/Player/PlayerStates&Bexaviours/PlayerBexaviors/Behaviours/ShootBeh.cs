using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.PlayerBehaviours.Base;

namespace Player.PlayerBehaviours.Behaviours
{
    public class ShootBeh : BehavioursBase
    {
        public override void EneterBexaviour()
        {
            Shot();
        }

        public override void ExitBexaviour()
        {
            Shot();
        }

        public override void FixedUpdateBexaviour()
        {
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