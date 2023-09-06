using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lee
{

    public class LoadButton : MonoBehaviour
    {
        public void OnLoad()
        {
            SaveData.Current = (SaveData)SerializetionManager.Load(Application.persistentDataPath + "/saves/Save.save");
        }
    }
}
