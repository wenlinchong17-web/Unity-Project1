using UnityEngine;
using Enemy.Runtime;

namespace Enemy.Runtime.Combat
{
    public class AttackCooldown
    {
        private readonly EnemyContext _context;

        private float _timer;

        public AttackCooldown(EnemyContext context)
        {
            _context = context;
            _timer = 0f;
        }

        public void Tick()
        {
            if (_timer > 0f)
                _timer -= _context.DeltaTime;
        }

        public bool IsReady()
        {
            return _timer <= 0f;
        }

        public void Reset()
        {
            _timer = _context.Config.AttackCoolDown;
        }
    }
}