using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy.Context
{
    public class EnemyStateMoveContext : IContextBase
    {
        public EnemyStateMoveContext(EnemyBase enemy) 
        {
            this.enemy = enemy;
        }
        public readonly EnemyBase enemy;
        public event Action onTryTransitionState;
        public float timeAFC { get; private set; } = 5f;

        private bool _isFollow;
        public bool isFollowTarget => _isFollow;

        private bool _isLook;
        public bool isLookTarget => _isLook;

        private bool _isRandomRotate;
        public bool isRandomRotate => _isRandomRotate;

        private bool _isRandomMove;
        public bool isRandomMove => _isRandomMove;

        private bool _isIdle;
        public bool isIdle => _isIdle;

        private float time;




        public void UpdateContext()
        {
            Threchold();
            SetIsRanMove(!isIdle && !isFollowTarget);
            SetIsRanRotate(!isLookTarget);
            SetIsLook(IsMinDistance(enemy._minDistanceLookTarget));
            SetIsFollow(IsMinDistance(enemy._minDistanceFollowTarget));
        }
       

        public bool IsMinDistance(float minDistance)
        {
            return Vector3.Distance(enemy._enemyTr.position, enemy._playerTr.position) <= minDistance;
        }

        private void Threchold()
        {
            timeAFC -= Time.deltaTime;
            if (timeAFC <= 0)
            {
                timeAFC = UnityEngine.Random.Range(3, 10);
                if (!isFollowTarget) IdleWaiteTime();
                
            }
        }
        private void IdleWaiteTime()
        {
            if (time < Time.time)
            {
                time = UnityEngine.Random.Range(3, 10)+ Time.time;
                SetIsIdle(UnityEngine.Random.value>=0.5f);
            }
            
        }

        public void SetIsFollow(bool _isFollow)
        {
            if (this._isFollow == _isFollow) return;
            this._isFollow = _isFollow;
            onTryTransitionState?.Invoke();
        }

        public void SetIsLook(bool _isLook)
        {
            if (this._isLook == _isLook) return;
            this._isLook = _isLook;
            onTryTransitionState?.Invoke();
        }

        public void SetIsRanMove(bool _isRanMove)
        {
            if (this._isRandomMove == _isRanMove) return;
            this._isRandomMove = _isRanMove;
            onTryTransitionState?.Invoke();
        }

        public void SetIsRanRotate(bool _isRanRotate)
        {
            if (this._isRandomRotate == _isRanRotate) return;
            this._isRandomRotate = _isRanRotate;
            onTryTransitionState?.Invoke();
        }

        public void SetIsIdle(bool _isIdle)
        {
            if (this._isIdle == _isIdle) return;
            this._isIdle = _isIdle;
            onTryTransitionState?.Invoke();
        }
    }
}