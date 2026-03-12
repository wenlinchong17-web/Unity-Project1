using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared.Data
{
    [System.Serializable]
    public class AttackData
    {
        public float BaseDamage;
        public float CriticalChance;
        public float CriticalMultiplier;

        public Vector2 Force;

        public DamageType DamageType = DamageType.Normal;
    }
}