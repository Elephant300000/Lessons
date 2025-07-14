using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.PlayerBehaviours.Base;
using UnityEngine.InputSystem;

namespace Player.PlayerBehaviours.Behaviours
{

    public class WalckBeh : BehavioursBase
    {
        public override void EneterBexaviour()
        {
        }

        public override void ExitBexaviour()
        {
        }

        public override void FixedUpdateBehaviour()
        {
            InputMove(new InputAction.CallbackContext());
        }

        public override void InputMove(InputAction.CallbackContext ctx)
        {
            Debug.Log("Walk");
        }

        public override void LateUpdateBexaviour()
        {
        }

        public override void UpdateBexaviour()
        {
        }
    }
}