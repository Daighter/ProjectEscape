using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Darik
{
    public class DataManager : MonoBehaviour
    {
        public bool isFacilityDoorOpen = false;
        public bool isCorridorDoorOpen = false;
        public bool isElevatorPowerOn = false;
        public int elevatorCurFloor = -2;

        public bool isLantonNumberingSet = false;

        public GameObject[] runeBox = new GameObject[4];

        public bool isDungeonRoomClear { get; private set; }
        public bool isPrisonRoomClear { get; private set; }
        public bool isCaveRoomClear { get; private set; }

        private void Start()
        {
            SetRandomColor();
        }

        public void DungeonClear()
        {
            isDungeonRoomClear = true;
        }

        public void PrisonClear()
        {
            isPrisonRoomClear = true;
        }

        public void CaveClear()
        {
            isCaveRoomClear = true;
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

            Debug.Log($"���� Ż��� : {colors[0]}");
            Debug.Log($"���� Ż��� : {colors[1]}");
            Debug.Log($"���� Ż��� : {colors[2]}");
            Debug.Log($"���� Ż��� : {colors[3]}");
        }

        public void SetPendantColor(int sceneNum, Renderer renderer)
        {
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

                case Color.None:
                    material = GameManager.Resource.Load<Material>("Prefabs/Puzzles/Pendant/JewalColors/None");
                    material.color = UnityEngine.Color.white;
                    break;
            }

            return material;
        }
        #endregion

        #region DungeonRecipe
        public GameObject[] recipeDolls = new GameObject[3];
        #endregion

        #region CaveTime
        private int[] times = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

        public int[] caveTime = new int[3];
        public bool isCaveLantonClear = false;
        #endregion
    }
}
