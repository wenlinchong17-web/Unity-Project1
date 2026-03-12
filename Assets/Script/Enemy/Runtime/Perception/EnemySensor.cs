using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shared.Contracts;
using Enemy.Runtime.Data;

namespace Enemy.Runtime.Perception
{
    public class EnemySensor
    {   
        private readonly Transform _origin;
        private readonly LayerMask _mask;
        private readonly Collider2D[] _buffer = new Collider2D[16];
         public EnemySensor(Transform origin, LayerMask targetMask)
        {
            _origin = origin;
            _mask = targetMask;
        }
        public ITargetable FindTarget(float range)
        {
            int count = Physics2D.OverlapCircleNonAlloc(
                _origin.position,
                range,
                _buffer,
                _mask
            );

            for (int i = 0; i < count; i++)
            {
                var hit = _buffer[i];
                var target = hit.GetComponent<ITargetable>();

                if (target != null && target.IsAlive)
                    return target;
            }

            return null;
        }
    }
}