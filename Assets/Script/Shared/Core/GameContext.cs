using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared.Core
{
    public static class GameContext
    {
        public static TimeService Time { get; private set; }
        public static EventBus Events { get; private set; }
        //以后可以扩展
        /*
        InputService
        AudioService
        SaveService
        */

        private static bool _initialized = false;
        public static void Initialize()
        {
            if (_initialized)
                return;
            Time = new TimeService();
            Events = new EventBus();
            _initialized = true;
        }
    }
}
