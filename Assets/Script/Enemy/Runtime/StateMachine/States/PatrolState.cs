using UnityEngine;
using Shared.Contracts;

namespace Enemy.Runtime.StateMachine
{
    public class PatrolState : IState
    {
        private readonly Enemy _enemy;
        private Vector2 _targetPoint;

        public PatrolState(Enemy enemy)
        {
            _enemy = enemy;
        }

        public void Enter()
        {
            PickPoint();
        }

        public void Exit()
        {
            _enemy.Stop();
        }

        public void Tick()
        {
            Vector2 pos = _enemy.Context.Transform.position;

            Vector2 dir = _targetPoint - pos;

            if (dir.magnitude < 0.2f)
            {
                PickPoint();
                return;
            }

            _enemy.Face(dir);
            _enemy.Move(dir);
        }

        void PickPoint()
        {
            float radius = _enemy.Context.Config.PatrolRadius;

            Vector2 center = _enemy.Context.Transform.position;

            _targetPoint = center + Random.insideUnitCircle * radius;
        }
    }
}