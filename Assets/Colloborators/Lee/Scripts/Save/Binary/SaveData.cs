using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lee
{
    [System.Serializable]
    public class SaveData
    {
        private static SaveData _current;

        public List<ObjectData> objList;
        public List<InventoryData> invenList;
        public List<ColorData> colorList;
        public List<NomalObjData> nomalObjList;

        public static SaveData current
        {
            get
            {
                if (_current == null)
                {
                    _current = new SaveData();
                }
                return _current;
            }
            set { _current = value; }
        } 
    }
}
    

