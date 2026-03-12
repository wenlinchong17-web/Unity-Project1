using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared.Contracts
{
    public interface ITargetable
    {
        Transform TargetPoint { get; }
        bool IsAlive { get; }
    }
}
