using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared.Contracts
{
    using Shared.Data;
    public interface IDamageable
    {
        void TakeDamage(DamageData damage);
        bool IsAlive { get; }
    }
}
