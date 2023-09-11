using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lee
{
    public class SaveLoadUI : MonoBehaviour
    {
        public void OnSave()
        {
            GameManager.Event.PostNotification(EventType.OnSave, this);
            SaveManager_Binary.Save("ObjectSave", SaveData.current);
        }

        public void OnLoad()
        {
            SaveData.current = (SaveData)SaveManager_Binary.Load(Application.persistentDataPath + "/saves/ObjectSave.save");
            GameManager.Event.PostNotification(EventType.OnLoad, this);
        }


    }
}
