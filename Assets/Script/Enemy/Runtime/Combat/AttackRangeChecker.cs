using UnityEngine;
using Shared.Contracts;
using Enemy.Runtime;

namespace Enemy.Runtime.Combat
{
    public class AttackRangeChecker
    {
        private readonly EnemyContext _context;

        public AttackRangeChecker(EnemyContext context)
        {
            _context = context;
        }

        public bool IsTargetInRange(ITargetable target)
        {
            if (target == null)
                return false;

            if (!target.IsAlive)
                return false;

            if (target.TargetPoint == null)
                return false;

            float range = _context.Config.AttackRange;

            float distance = Vector2.Distance(
                _context.Transform.position,
                target.TargetPoint.position
            );

            return distance <= range;
        }
    }
}