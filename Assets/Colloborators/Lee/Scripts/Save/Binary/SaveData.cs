using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lee
{
    [System.Serializable]
    public class SaveData
    {
        public static SaveData current;

        public List<ObjectData> objs;
    }
}
