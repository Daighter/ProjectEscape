using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Darik
{
    public class DataManager : MonoBehaviour
    {
        private void Start()
        {
            SetRandomColor();
        }

        #region PendantColor
        public enum Color { None, Red, Orange, Yellow, Green, Blue, Purple, Size }

        public Color[] colors;

        public void SetRandomColor()
        {
            colors = new Color[4];

            for (int i = 0; i < 4; i++)
            {
                int index = Random.Range(1, (int)Color.Size);
                if (colors.Contains((Color)index))
                {
                    i--;
                    continue;
                }

                colors[i] = (Color)index;
            }

            foreach (Color color in colors)
            {
                Debug.Log(color);
            }
        }

        public void SetColor(int sceneNum)
        {
            Debug.Log(colors[sceneNum]);
        }
        #endregion

        private string[] dolls = { "", "", "", "", "", "" };
        private int[] times = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

        public string[] recipeDolls = new string[3];

        public int[] caveTime = new int[3];
        public bool isCaveClear = false;
    }
}
