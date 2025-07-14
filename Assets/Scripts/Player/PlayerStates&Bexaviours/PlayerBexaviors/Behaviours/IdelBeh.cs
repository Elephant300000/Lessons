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
        }

        public override void ExitBexaviour()
        {
        }

        public override void FixedUpdateBehaviour() 
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
