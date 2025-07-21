using Player.PlayerBehaviours.Base;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.PlayerBehaviours.Behaviours
{
    public class RunBehaviourPlayer : BehaviourPlayerBase
    {
        public RunBehaviourPlayer(PlayerInfo playerInfo) : base(playerInfo)
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