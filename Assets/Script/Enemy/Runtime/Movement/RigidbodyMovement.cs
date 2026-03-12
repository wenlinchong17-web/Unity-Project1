using UnityEngine;
using Enemy.Runtime;
using Shared.Contracts;
namespace Enemy.Runtime.Movement
{
    public class RigidbodyMovement : IMovementStrategy,IMovable
    {
        private readonly EnemyContext _context;

        public RigidbodyMovement(EnemyContext context)
        {
            _context = context;
        }

        public void Move(Vector2 direction)
        {
            if (_context.Rigidbody == null)
                return;

            if (direction == Vector2.zero)
                return;

            direction = direction.normalized;

            Vector2 velocity = direction * _context.Config.MoveSpeed;

            _context.Rigidbody.velocity = velocity;
        }

        public void Stop()
        {
            if (_context.Rigidbody == null)
                return;

            _context.Rigidbody.velocity = Vector2.zero;
        }
    }
}