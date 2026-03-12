using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Shared.Utils
{
    using UnityEngine;

    public static class LayerMaskUtil
    {
        public static bool IsInLayerMask(GameObject obj, LayerMask mask)
        {
            return (mask.value & (1 << obj.layer)) != 0;
        }
    }
}