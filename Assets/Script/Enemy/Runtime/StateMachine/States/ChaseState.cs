using UnityEngine;
using Shared.Contracts;

namespace Enemy.Runtime.StateMachine
{
    public class ChaseState : IState
    {
        private readonly Enemy _enemy;

        public ChaseState(Enemy enemy)
        {
            _enemy = enemy;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
            _enemy.Stop();
        }

        public void Tick()
        {
            if (!_enemy.HasTarget())
                return;

            var target = _enemy.Context.CurrentTarget;

            Vector2 targetPos = target.TargetPoint.position;

            Vector2 pos = _enemy.Context.Transform.position;

            Vector2 dir = targetPos - pos;

            _enemy.Face(dir);
            _enemy.Move(dir);
        }
    }
}