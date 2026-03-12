using UnityEngine;
using Shared.Contracts;
using Shared.Data;
using Enemy.Runtime;

namespace Enemy.Runtime.Combat
{
    public class AttackExecutor
    {
        private readonly EnemyContext _context;

        public AttackExecutor(EnemyContext context)
        {
            _context = context;
        }

        public void Execute(IDamageable target)
        {
            if (target == null)
                return;

            var attack = _context.Config.Attack;

            DamageData damage =
                DamageData.CreateFromAttack(
                    attack,
                    _context.Transform.gameObject
                );

            target.TakeDamage(damage);
        }
    }
}