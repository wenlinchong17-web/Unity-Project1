using UnityEngine;
using Enemy.Runtime;
using Enemy.Runtime.Data;
using Shared.Contracts;
using Shared.Data; // <- 修复 DamageData
using Shared.Core;
using Shared.Events;

namespace Enemy.Presentation
{
    public class EnemyController :
        MonoBehaviour,
        ITargetable,
        IDamageable
    {
        [Header("Enemy Config")]
        [SerializeField] private EnemyConfig config;

        [Header("Target Mask")]
        [SerializeField] private LayerMask playerMask;

        [Header("Debug Gizmos")]
        public bool showGizmos = true;

        public ITargetable currentTarget;

        private void OnDrawGizmosSelected()
        {
            if (!showGizmos || config == null)
                return;

            Vector3 pos = transform.position;

            // 1 巡逻范围
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(pos, config.PatrolRadius);

            // 2 发现玩家范围 (ChaseRange)
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(pos, config.ChaseRange);

            // 3 丢失目标范围 (LoseTargetRange)
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(pos, config.LoseTargetRange);

            // 4 攻击范围
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(pos, config.AttackRange);

            // 5 朝向箭头
            Gizmos.color = Color.blue;
            Vector3 forward = transform.right; // 假设 x 方向为朝向
            Gizmos.DrawLine(pos, pos + forward * 1.5f);
            Gizmos.DrawSphere(pos + forward * 1.5f, 0.1f);

            // 6 当前目标位置
            if (currentTarget != null && currentTarget.TargetPoint != null)
            {
                Gizmos.color = Color.magenta;
                Gizmos.DrawLine(pos, currentTarget.TargetPoint.position);
                Gizmos.DrawSphere(currentTarget.TargetPoint.position, 0.2f);
            }
        }
        private Enemy.Runtime.Enemy enemy;
        private EnemyContext context;

        private Rigidbody2D rb;
        private EnemyAnimationController animationController;
        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animationController = GetComponent<EnemyAnimationController>();
            InitializeEnemy();
        }

        void InitializeEnemy()
        {
            enemy = new Enemy.Runtime.Enemy();

            context = new EnemyContext();

            context.Init(
                config,
                transform,
                rb,
                this
            );

            enemy.Initialize(context, playerMask);
        }

        void Update()
        {
            enemy?.Update();
            UpdateAnimation();
            currentTarget = context.CurrentTarget;
        }

        void UpdateAnimation()
        {
            if (animationController == null)
                return;

            float speed = rb.velocity.magnitude;

            animationController.SetMoveSpeed(speed);
        }

        // ITargetable
        public Transform TargetPoint
        {
            get { return transform; }
        }

        public bool IsAlive
        {
            get { return context.CurrentHP > 0; }
        }


        // IDamageable
        public void TakeDamage(Shared.Data.DamageData damage)
        {
            context.TakeDamage(damage);

            if (!IsAlive)
            {
                OnDeath();
            }
        }

        void OnDeath()
        {
            enemy.Stop();
            animationController?.PlayDeath();
            Destroy(gameObject);
        }
    }
}