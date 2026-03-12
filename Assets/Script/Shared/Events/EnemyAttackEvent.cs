using Shared.Contracts;
using Shared.Data;

namespace Shared.Events
{
    public class EnemyAttackEvent
    {
        public IDamageable Attacker { get; }
        public IDamageable Target { get; }
        public DamageData Damage { get; }

        public EnemyAttackEvent(IDamageable attacker, IDamageable target, DamageData damage)
        {
            Attacker = attacker;
            Target = target;
            Damage = damage;
        }
    }
}