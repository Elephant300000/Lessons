using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy.Context
{
    public class EnemyStateMoveContext : IContextEvent
    {
        public EnemyStateMoveContext(EnemyBase enemy) 
        {
            this.enemy = enemy;
        }
        public readonly EnemyBase enemy;
        public event Action onTryTransitionState;
        public float timeAFC { get; private set; } = 5f;
        private bool _isIdle = true;
        public bool isIdle 
        {
            get => _isIdle;
            set 
            {
                if (_isIdle == value) return;
                    _isIdle = value;
                onTryTransitionState?.Invoke();
            }
            
        }
        private bool _isFollowTarget = true;
        public bool isFollowTarget
        {
            get => _isFollowTarget;
            set
            {
                if (_isFollowTarget == value) return;
                _isFollowTarget = value;
                onTryTransitionState?.Invoke();
            }

        }
        private bool _isRandomMove = true;
        public bool isRandomMove
        {
            get => _isRandomMove;
            set
            {
                if (_isRandomMove == value) return;
                _isRandomMove = value;
                onTryTransitionState?.Invoke();
            }

        }
        private bool _isLookTarget = true;
        public bool isLookTarget
        {
            get => _isLookTarget;
            set
            {
                if (_isLookTarget == value) return;
                _isLookTarget = value;
                onTryTransitionState?.Invoke();
            }

        }
        private bool _isRandomRotate = true;
        public bool isRandomRotate
        {
            get => _isRandomRotate;
            set
            {
                if (_isRandomRotate == value) return;
                _isRandomRotate = value;
                onTryTransitionState?.Invoke();
            }

        }
        private float time;




        public void UpdateContext()
        {
            Threchold();
            isRandomMove = !isIdle && !isFollowTarget;
            isRandomRotate = !isLookTarget;
            isLookTarget = IsMinDistance(enemy._minDistanceLookTarget);
            isFollowTarget = IsMinDistance(enemy._minDistanceFollowTarget);
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
                isIdle = UnityEngine.Random.value>=0.5f;
            }
            
        }
    }
}