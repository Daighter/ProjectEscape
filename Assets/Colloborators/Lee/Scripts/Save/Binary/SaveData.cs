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
        
        public static SaveData current
        {
            get
            {
                if (_current == null)
                {
                    _current = new SaveData();
                    _current.objList = new List<ObjectData>();
                }
                return _current;
            }
            set { _current = value; }
        } 
    }
}
    

