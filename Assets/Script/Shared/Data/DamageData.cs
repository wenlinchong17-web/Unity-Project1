using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared.Data
{
    [System.Serializable]
    public struct DamageData
    {
        public float Amount;
        public Vector2 HitPoint;
        public Vector2 Force;
        public bool IsCritical;
        public DamageType DamageType;
        public GameObject Source;
        public DamageData(float amount)
        {
            Amount = amount;
            HitPoint = Vector2.zero;
            Force = Vector2.zero;
            DamageType = DamageType.Normal;
            IsCritical = false;
            Source = null;
        }
        public static DamageData CreateFromAttack(AttackData attack, GameObject source)
        {
            DamageData damage = new DamageData(attack.BaseDamage);
            damage.IsCritical = Random.value <= attack.CriticalChance;
            if (damage.IsCritical)
                damage.Amount *= attack.CriticalMultiplier;

            damage.DamageType = attack.DamageType;
            damage.Force = attack.Force;
            damage.Source = source;
            return damage;
        }
    }
}
