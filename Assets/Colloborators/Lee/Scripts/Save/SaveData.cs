using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lee
{
    [System.Serializable]
    public class SaveData : MonoBehaviour
    {
        private static SaveData current;
        public static SaveData Current { get { return current; } set { if (current == null) { current = new SaveData(); } } }

        public PlayerData playerData;
        public int interatorObject;


    }
}
