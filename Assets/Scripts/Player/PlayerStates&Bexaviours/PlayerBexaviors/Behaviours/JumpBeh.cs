using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.PlayerBehaviours.Base;

namespace Player.PlayerBehaviours.Behaviours
{

    public class JumpBeh : BehavioursBase
    {
        public override void EneterBexaviour()
        {
            Jump();
        }

        public override void ExitBexaviour()
        {
            Jump();
        }

        public override void FixedUpdateBexaviour()
        {
        }

        public override void Jump()
        {
            Debug.Log("Jump");
        }

        public override void LateUpdateBexaviour()
        {
        }

        public override void UpdateBexaviour()
        {
        }
    }
}