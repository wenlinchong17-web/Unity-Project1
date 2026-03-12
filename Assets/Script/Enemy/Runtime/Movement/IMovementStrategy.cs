using UnityEngine;

namespace Enemy.Runtime.Movement
{
    public interface IMovementStrategy
    {
        void Move(Vector2 direction);
        void Stop();
    }
}