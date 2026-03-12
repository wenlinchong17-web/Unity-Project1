using System;
using System.Collections.Generic;
using Shared.Contracts;

namespace Enemy.Runtime.StateMachine
{
    public class EnemyStateMachine : IStateMachine
    {
        private readonly Dictionary<Type, IState> _states = new();

        public IState CurrentState { get; private set; }

        public void AddState(IState state)
        {
            _states[state.GetType()] = state;
        }

        public void ChangeState<T>() where T : IState
        {
            if (CurrentState != null && CurrentState is T)
                return;

            CurrentState?.Exit();

            var type = typeof(T);

            if (_states.TryGetValue(type, out var newState))
            {
                CurrentState = newState;
                CurrentState.Enter();
            }
        }

        public void Tick()
        {
            CurrentState?.Tick();
        }
    }
}