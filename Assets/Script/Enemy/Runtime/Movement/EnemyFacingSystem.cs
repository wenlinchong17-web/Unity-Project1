using UnityEngine;

namespace Enemy.Runtime.Movement
{
    public class EnemyFacingSystem
    {
        private readonly IFacingStrategy _facing;

        public EnemyFacingSystem(EnemyContext context)
        {
            _facing = new SpriteFlipFacing(context);
        }

        public void Face(Vector2 direction)
        {
            _facing.Face(direction);
        }
    }
}