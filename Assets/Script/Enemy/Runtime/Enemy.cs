using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Shared.Contracts;
using Shared.Data;
using Shared.Core;
using Enemy.Runtime.Perception;
using Enemy.Runtime.Movement;
using Enemy.Runtime.Combat;
using Enemy.Runtime.AI;
using Enemy.Runtime.StateMachine;

namespace Enemy.Runtime
{
    public class Enemy :
        IDamageable,
        IAttacker,
        IMovable,
        IFacing,
        ITargetable
    {
        public EnemyContext Context { get; private set; }
        public IEnemyAI AI { get; set; }
        public IEnemyPerception Perception { get; set; }
        public IStateMachine StateMachine { get; set; }

        public IMovable Movement { get; set; }
        public IFacing Facing { get; set; }
        public EnemyCombatSystem Combat { get; private set; }
        public void Initialize(EnemyContext context, LayerMask playerMask)
        {
            Context = context;
            InitPerception(playerMask);
            InitMovement();
            InitCombat();
            InitAI();
        }
        private void InitPerception(LayerMask playerMask)
        {
            var sensor = new EnemySensor(
                Context.Transform,
                playerMask
            );

            Perception = new EnemyPerception(
                Context,
                sensor
            );
        }

        private void InitMovement()
        {
            Movement = new  global::Enemy.Runtime.Movement.RigidbodyMovement(Context);
            Facing = new  global::Enemy.Runtime.Movement.SpriteFlipFacing(Context);
        }

        private void InitCombat()
        {
            Combat = new EnemyCombatSystem(Context);
        }

        private void InitAI()
        {
            var sm = new EnemyStateMachine();

            sm.AddState(new IdleState(this));
            sm.AddState(new PatrolState(this));
            sm.AddState(new ChaseState(this));
            sm.AddState(new AttackState(this));
            sm.AddState(new ReturnState(this));

            StateMachine = sm;

            AI = new EnemyAI(this, sm);

            sm.ChangeState<IdleState>();
        }
        public void Update()
        {
            // ?.表示防止null
            Perception?.Update();
            StateMachine?.Tick();
            AI?.Update();
            Combat?.Tick();
        }

        public Transform TargetPoint
        {
            get { return Context.Transform; }
        }

        public bool IsAlive
        {
            get { return Context.CurrentHP > 0; }
        }

        public void TakeDamage(DamageData damage)
        {
            Context.TakeDamage(damage);
        }

        public void Attack(IDamageable target)
        {
            if (target == null || !IsAlive)
                return;

            var attack = Context.Config.Attack;

            DamageData damage = DamageData.CreateFromAttack(attack, Context.Transform.gameObject);

            target.TakeDamage(damage);
            GameContext.Events.Publish(new Shared.Events.EnemyAttackEvent(this, target, damage));
        }




        public void Move(Vector2 direction)
        {
            if (Movement != null)
                Movement.Move(direction);  // 这应该可以工作
        }

        public void Stop()
        {
            if (Movement != null)
                Movement.Stop();           // 这应该可以工作
        }

        public void Face(Vector2 direction)
        {
            if (Facing != null)
                Facing.Face(direction);    // 这应该可以工作
        }
        public void SetTarget(ITargetable target)
        {
            Context.SetTarget(target);
        }

        public void ClearTarget()
        {
            Context.ClearTarget();
        }

        public bool HasTarget()
        {
            return Context.HasTarget();
        }
    }
}