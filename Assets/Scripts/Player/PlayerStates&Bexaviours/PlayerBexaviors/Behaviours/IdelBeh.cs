using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.PlayerBehaviours.Base;

namespace Player.PlayerBehaviours.Behaviours
{
    public class IdelBeh : BehavioursBase
    {
        public override void EneterBexaviour()
        {
            Idel();
        }

        public override void ExitBexaviour()
        {
            Idel();
        }

        public override void FixedUpdateBexaviour()
        {
            Idel();
        }

        public override void Idel()
        {
            Debug.Log("Idel");
        }

        public override void LateUpdateBexaviour()
        {
        }

        public override void UpdateBexaviour()
        {
        }
    }
}
