using UnityEngine;

namespace Enemy.Runtime.Movement
{
    public interface IFacingStrategy
    {
        void Face(Vector2 direction);
    }
}