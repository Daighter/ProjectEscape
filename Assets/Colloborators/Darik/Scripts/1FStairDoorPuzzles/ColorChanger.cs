using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class ColorChanger : MonoBehaviour
    {
        [SerializeField] private Renderer jewal;

        private int curIndex = 1;

        public int CurIndex { get { return curIndex; } set { curIndex = value; jewal.material = GameManager.Data.LoadMaterial((DataManager.Color)curIndex); } }

        public void ChangeColor()
        {
            curIndex++;
            if (curIndex == 7)
                curIndex = 1;
            jewal.material = GameManager.Data.LoadMaterial((DataManager.Color)curIndex);
        }
    }
}
