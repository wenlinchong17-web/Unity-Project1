using Shared.Contracts;

namespace Shared.Events
{
    public class EnemyDiedEvent
    {
        public IDamageable Enemy { get; }

        public EnemyDiedEvent(IDamageable enemy)
        {
            Enemy = enemy;
        }
    }
}