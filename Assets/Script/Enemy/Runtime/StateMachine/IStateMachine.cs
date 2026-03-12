using Shared.Contracts;

namespace Enemy.Runtime.StateMachine
{
    public interface IStateMachine
    {
        void ChangeState<T>() where T : IState;
        void Tick();
    }
}