using UnityEngine;
using Shared.Core;

namespace Bootstrap
{
    public class GameBootstrap : MonoBehaviour
    {
        void Awake()
        {
            GameContext.Initialize();
        }

        void Update()
        {
            GameContext.Events.ProcessEvents();
        }
    }
}