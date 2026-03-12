using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared.Core
{
    public class TimeService
    {
        public float DeltaTime=>  UnityEngine.Time.deltaTime;
        public float FixedDeltaTime =>  UnityEngine.Time.fixedDeltaTime;
        public float Time => UnityEngine.Time.time;

    }
}