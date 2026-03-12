using Shared.Contracts;

namespace Shared.Events
{
    public class EnemyTargetChangedEvent
    {
        public IDamageable Enemy { get; }
        public ITargetable OldTarget { get; }
        public ITargetable NewTarget { get; }

        public EnemyTargetChangedEvent(IDamageable enemy, ITargetable oldTarget, ITargetable newTarget)
        {
            Enemy = enemy;
            OldTarget = oldTarget;
            NewTarget = newTarget;
        }
    }
}