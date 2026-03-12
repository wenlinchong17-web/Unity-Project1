using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Enemy.Runtime.Data;
using Shared.Contracts;
using Shared.Core;
using Shared.Events;
using Shared.Data;
namespace Enemy.Runtime
{
    public class EnemyContext
    {
        public Rigidbody2D Rigidbody;
        public Transform Transform;
        public Data.EnemyConfig Config;

        public float CurrentHP;
        // 运行时系统引用（后续阶段注入）
        public IDamageable SelfDamageable;
        public ITargetable CurrentTarget;

        public void Init(EnemyConfig config, Transform transform, Rigidbody2D rigidbody, IDamageable self)
        {
            Config = config;
            Transform = transform;
            Rigidbody = rigidbody;
            CurrentHP = config.MaxHP;
            SelfDamageable = self;
            CurrentTarget = null;
        }
        public void TakeDamage(DamageData damage)
        {
            if (CurrentHP <= 0) return;//防止重复死亡
            CurrentHP -= damage.Amount;
            if (CurrentHP <= 0)
            {
                CurrentHP = 0;
                Die();
            }
        }
        public void Heal(float amount)
        {
            CurrentHP += amount;
            if (CurrentHP > Config.MaxHP)
                CurrentHP = Config.MaxHP;
        }
        public void Die()
        {
            //发布死亡事件
            GameContext.Events.Publish(new EnemyDiedEvent(SelfDamageable));
        }
        public void SetTarget(ITargetable target)
        {
            if (target == null || !target.IsAlive)
                return;

            var oldTarget = CurrentTarget;
            CurrentTarget = target;

            GameContext.Events.Publish(new Shared.Events.EnemyTargetChangedEvent(SelfDamageable, oldTarget, target));
        }
        public void ClearTarget()
        {
            CurrentTarget = null;
        }
        public bool HasTarget()
        {
            return CurrentTarget != null && CurrentTarget.IsAlive;
        }
        public float DistanceToTarget()
        {
            if (!HasTarget())
                return float.MaxValue;
            if (CurrentTarget.TargetPoint == null)
                return float.MaxValue;

            return Vector2.Distance(
                Transform.position,
                CurrentTarget.TargetPoint.position
            );
        }

        public bool IsTargetInRange(float range)
        {
            return DistanceToTarget() <= range;
        }
        public float DeltaTime => GameContext.Time.DeltaTime;
    }
}