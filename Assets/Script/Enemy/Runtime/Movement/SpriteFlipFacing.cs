using UnityEngine;
using Enemy.Runtime;
using Shared.Contracts;
namespace Enemy.Runtime.Movement
{
    public class SpriteFlipFacing : IFacingStrategy,IFacing
    {
        private readonly EnemyContext _context;

        public SpriteFlipFacing(EnemyContext context)
        {
            _context = context;
        }

        public void Face(Vector2 direction)
        {
            if (direction.x == 0)
                return;

            Vector3 scale = _context.Transform.localScale;

            if (direction.x > 0)
                scale.x = Mathf.Abs(scale.x);
            else
                scale.x = -Mathf.Abs(scale.x);

            _context.Transform.localScale = scale;
        }
    }
}