using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

namespace Darik
{
    public static class Extention
    {
        public static bool Contain(this LayerMask layerMask, int layer)
        {
            return ((1 << layer) & layerMask) != 0;
        }
    }
}
