using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared.Contracts
{
    public interface IState
    {
        void Enter();
        void Exit();
        void Tick();
    }
}