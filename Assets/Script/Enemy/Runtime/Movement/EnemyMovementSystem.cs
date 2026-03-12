using UnityEngine;
using Enemy.Runtime;

namespace Enemy.Runtime.Movement
{
    public class EnemyMovementSystem
    {
        private readonly EnemyContext _context;
        private readonly IMovementStrategy _movement;

        public EnemyMovementSystem(EnemyContext context)
        {
            _context = context;

            // 默认策略
            _movement = new RigidbodyMovement(context);
        }

        public void Move(Vector2 direction)
        {
            _movement.Move(direction);
        }

        public void Stop()
        {
            _movement.Stop();
        }
    }
}