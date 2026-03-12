using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared.Contracts
{
    public interface IAttacker
    {
        void Attack(IDamageable target);
    }
}