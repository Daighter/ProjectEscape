using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lee
{

    public class LoadButton : MonoBehaviour
    {
        public void OnLoad()
        {
            SaveManager.instance.LoadData();
        }
    }
}
