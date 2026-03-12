using Shared.Contracts;

namespace Shared.Events
{
    public class EnemySpawnedEvent
    {
        public IDamageable Enemy { get; }

        public EnemySpawnedEvent(IDamageable enemy)
        {
            Enemy = enemy;
        }
    }
}