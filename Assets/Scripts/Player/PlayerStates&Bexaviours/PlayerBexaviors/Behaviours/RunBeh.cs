using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.PlayerBehaviours.Base;
using UnityEngine.InputSystem;
namespace Player.PlayerBehaviours.Behaviours
{
    public class RunBeh : BehavioursBase
    {
        public override void EneterBexaviour()
        {
        }

        public override void ExitBexaviour()
        {
        }

        public override void FixedUpdateBehaviour()
        {
            Run(new InputAction.CallbackContext());
        }

        public override void LateUpdateBexaviour()
        {
        }

        public override void Run(InputAction.CallbackContext ctx)
        {
            Debug.Log("Run");
        }

        public override void UpdateBexaviour()
        {
        }
    }
}