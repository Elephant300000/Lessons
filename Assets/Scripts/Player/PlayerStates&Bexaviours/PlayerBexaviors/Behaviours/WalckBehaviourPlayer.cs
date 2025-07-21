using Player.PlayerBehaviours.Base;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.PlayerBehaviours.Behaviours
{

    public class WalckBehaviourPlayer : BehaviourPlayerBase
    {
        public WalckBehaviourPlayer(PlayerInfo playerInfo) : base(playerInfo)
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