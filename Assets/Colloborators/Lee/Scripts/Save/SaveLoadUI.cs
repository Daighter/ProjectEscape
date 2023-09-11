using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lee
{
    public class SaveLoadUI : MonoBehaviour
    {
        public void OnSave()
        {
            SaveManager_Binary.Save("ObjectSave", SaveData.current);
            GameManager.ObjM.SaveObj();
            
        }

        public void OnLoad()
        {
            SaveData.current = (SaveData)SaveManager_Binary.Load(Application.persistentDataPath + "/saves/ObjectSave.save");
            GameManager.ObjM.LoadObj();
        }


    }
}
