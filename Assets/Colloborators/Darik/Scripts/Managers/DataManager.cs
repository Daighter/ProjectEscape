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

        public void SetPendantColor(int sceneNum, Renderer renderer)
        {
            Debug.Log(colors[sceneNum]);
            renderer.material = LoadMaterial(colors[sceneNum]);
        }

        public Material LoadMaterial(Color color)
        {
            Material material = null;

            switch (color)
            {
                case Color.Red:
                    material = GameManager.Resource.Load<Material>("Prefabs/Puzzles/Pendant/JewalColors/Red");      break;
                case Color.Orange:
                    material = GameManager.Resource.Load<Material>("Prefabs/Puzzles/Pendant/JewalColors/Orange");   break;
                case Color.Yellow:
                    material = GameManager.Resource.Load<Material>("Prefabs/Puzzles/Pendant/JewalColors/yellow");   break;
                case Color.Green:
                    material = GameManager.Resource.Load<Material>("Prefabs/Puzzles/Pendant/JewalColors/Green");    break;
                case Color.Blue:
                    material = GameManager.Resource.Load<Material>("Prefabs/Puzzles/Pendant/JewalColors/Blue");     break;
                case Color.Purple:
                    material = GameManager.Resource.Load<Material>("Prefabs/Puzzles/Pendant/JewalColors/Purple");   break;
            }

            return material;
        }
        #endregion

        #region DungeonRecipe
        private string[] dolls = { "", "", "", "", "", "" };

        public string[] recipeDolls = new string[3];
        #endregion

        #region CaveTime
        private int[] times = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

        public int[] caveTime = new int[3];
        public bool isCaveClear = false;
        #endregion
    }
}
