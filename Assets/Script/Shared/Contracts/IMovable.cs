using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared.Contracts
{
    public interface IMovable
    {
        void Move(Vector2 direction);
        void Stop();
    }
}
