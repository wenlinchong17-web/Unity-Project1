using UnityEngine;
using Shared.Contracts;

namespace Enemy.Runtime.StateMachine
{
    public class AttackState : IState
    {
        private readonly Enemy _enemy;

        public AttackState(Enemy enemy)
        {
            _enemy = enemy;
        }

        public void Enter()
        {
            _enemy.Stop();
        }

        public void Exit()
        {
        }

        public void Tick()
        {
            if (!_enemy.HasTarget())
                return;

            var target = _enemy.Context.CurrentTarget;

            Vector2 dir =
                target.TargetPoint.position -
                _enemy.Context.Transform.position;

            _enemy.Face(dir);

            if (_enemy.Combat.TryAttack(target))
            {
                var controller =
                    _enemy.Context.Transform
                    .GetComponent<EnemyAnimationController>();

                controller?.PlayAttack();
            }
        }
    }
}