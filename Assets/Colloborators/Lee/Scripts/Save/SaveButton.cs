using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lee
{
    public class SaveButton : MonoBehaviour
    {
        public void OnSave()
        {
            SaveManager.instance.SaveData();
        }
    }
}
