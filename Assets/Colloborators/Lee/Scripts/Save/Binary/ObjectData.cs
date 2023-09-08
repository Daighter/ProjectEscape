using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lee
{
    public enum ObjType
    {
        MainRoom,
        PrisonRoom,
        MineRoom,
        DungeonRoom,
    }

    [System.Serializable]
    public class ObjectData
    {
        public string id;

        public ObjType objtype;

        public Vector3 position;

        public Quaternion rotation;
    }
}
