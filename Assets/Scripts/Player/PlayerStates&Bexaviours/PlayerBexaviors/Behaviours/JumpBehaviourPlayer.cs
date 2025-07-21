using Player.PlayerBehaviours.Base;
using UnityEngine;

namespace Player.PlayerBehaviours.Behaviours
{

    public class JumpBehaviourPlayer : BehaviourPlayerBase
    {
        public JumpBehaviourPlayer(PlayerInfo playerInfo) : base(playerInfo)
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
            Jump();
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