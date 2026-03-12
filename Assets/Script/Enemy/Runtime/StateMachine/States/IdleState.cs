using Shared.Contracts;
using Enemy.Runtime;

namespace Enemy.Runtime.StateMachine
{
    public class IdleState : IState
    {
        private readonly Enemy _enemy;

        public IdleState(Enemy enemy)
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
        }
    }
}