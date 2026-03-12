using Shared.Contracts;

namespace Enemy.Runtime.StateMachine
{
    public class ReturnState : IState
    {
        private readonly Enemy _enemy;

        public ReturnState(Enemy enemy)
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
        }
    }
}