using Player.PlayerBehaviours.Base;
using UnityEngine;

namespace Player.PlayerBehaviours.Behaviours
{
    public class IdelBehaviourPlayer : BehaviourPlayerBase
    {
        public IdelBehaviourPlayer(PlayerInfo playerInfo) : base(playerInfo)
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
