using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared.Utils
{
    using UnityEngine;

    public static class MathUtil
    {
        public static Vector2 NormalizeSafe(Vector2 value)
        {
            return value == Vector2.zero ? Vector2.zero : value.normalized;
        }

        public static float Distance2D(Vector2 a, Vector2 b)
        {
            return Vector2.Distance(a, b);
        }
    }
}
