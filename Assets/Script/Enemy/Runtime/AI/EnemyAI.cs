using Enemy.Runtime;
using Enemy.Runtime.StateMachine;

namespace Enemy.Runtime.AI
{
    public class EnemyAI : IEnemyAI
    {
        private readonly Enemy _enemy;
        private readonly EnemyStateMachine _stateMachine;

        public EnemyAI(Enemy enemy, EnemyStateMachine stateMachine)
        {
            _enemy = enemy;
            _stateMachine = stateMachine;
        }

        public void Update()
        {
            var context = _enemy.Context;

            if (!_enemy.HasTarget())
            {
                if (!(_stateMachine.CurrentState is PatrolState))
                    _stateMachine.ChangeState<PatrolState>();

                return;
            }

            var target = context.CurrentTarget;

            float distance = context.DistanceToTarget();

            if (distance <= context.Config.AttackRange)
            {
                _stateMachine.ChangeState<AttackState>();
            }
            else
            {
                _stateMachine.ChangeState<ChaseState>();
            }
        }
    }
}