using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shared.Contracts;
using Enemy.Runtime.Data;
namespace Enemy.Runtime.Perception
{
    public class EnemyPerception : IEnemyPerception
    {
        private readonly EnemyContext _context;
        private readonly EnemySensor _sensor;

        public EnemyPerception(
            EnemyContext context,
            EnemySensor sensor)
        {
            _context = context;
            _sensor = sensor;
        }
        public void Update()
        {
            if (!_context.HasTarget())
            {
                FindTarget();
            }
            else
            {
                CheckLoseTarget();
            }
        }
        private void FindTarget()
        {
            float range = _context.Config.ChaseRange;

            ITargetable target = _sensor.FindTarget(range);

            if (target != null)
            {
                _context.SetTarget(target);
            }
        }

        private void CheckLoseTarget()
        {
            float loseRange = _context.Config.LoseTargetRange;

            if (!_context.IsTargetInRange(loseRange))
            {
                _context.ClearTarget();
            }
        }
    }
}