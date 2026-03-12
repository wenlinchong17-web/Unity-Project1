using UnityEngine;
using Shared.Contracts;
using Enemy.Runtime;

namespace Enemy.Runtime.Combat
{
    public class EnemyCombatSystem
    {
        private readonly EnemyContext _context;

        private readonly AttackCooldown _cooldown;
        private readonly AttackRangeChecker _rangeChecker;
        private readonly AttackExecutor _executor;

        public EnemyCombatSystem(EnemyContext context)
        {
            _context = context;

            _cooldown = new AttackCooldown(context);
            _rangeChecker = new AttackRangeChecker(context);
            _executor = new AttackExecutor(context);
        }

        public void Tick()
        {
            _cooldown.Tick();
        }

        public bool CanAttack(ITargetable target)
        {
            if (!_cooldown.IsReady())
                return false;

            if (!_rangeChecker.IsTargetInRange(target))
                return false;

            return true;
        }

        public bool TryAttack(ITargetable target)
        {
            if (!CanAttack(target))
                return false;

            var damageable = target as IDamageable;

            if (damageable == null)
                return false;

            _executor.Execute(damageable);

            _cooldown.Reset();

            return true;
        }
    }
}