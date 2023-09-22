using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

namespace Darik
{
    public class DataManager : MonoBehaviour
    {
        public bool isFacilityDoorOpen = false;
        public bool is1FStairDoorOpen = false;
        public bool isElevatorPowerOn = false;
        public int elevatorCurFloor = -2;

        public bool isLantonNumberingSet = false;

        public GameObject[] runeBox = new GameObject[4];

        public bool isDungeonRoomClear { get; private set; }
        public bool isPrisonRoomClear { get; private set; }
        public bool isCaveRoomClear { get; private set; }
        public bool isOpen { get; private set;}

        private void Start()
        {
            SetRandomColor();
            CashingColor();
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

        public void OpenChest()
        {
            isOpen = true;
        }

        #region PendantColor
        public enum Color { None, Red, Orange, Yellow, Green, Blue, Purple, Size }
        private Material[] palette;

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

            Debug.Log($"¸ÞÀÎ Å»Ãâ¹æ : {colors[0]}");
            Debug.Log($"µ¿±¼ Å»Ãâ¹æ : {colors[1]}");
            Debug.Log($"°¨¿Á Å»Ãâ¹æ : {colors[2]}");
            Debug.Log($"´øÀü Å»Ãâ¹æ : {colors[3]}");
        }

        public void SetPendantColor(int sceneNum, Renderer renderer)
        {
            renderer.material = LoadMaterial(colors[sceneNum]);
        }

        public Material LoadMaterial(Color color)
        {
            return palette[(int)color];
        }

        private void CashingColor()
        {
            palette = new Material[(int)Color.Size];

            for (int i = 0; i < palette.Length; i++)
            {
                switch ((Color)i)
                {
                    case Color.Red:
                        palette[i] = GameManager.Resource.Load<Material>("Prefabs/Puzzles/Pendant/JewalColors/Red"); break;
                    case Color.Orange:
                        palette[i] = GameManager.Resource.Load<Material>("Prefabs/Puzzles/Pendant/JewalColors/Orange"); break;
                    case Color.Yellow:
                        palette[i] = GameManager.Resource.Load<Material>("Prefabs/Puzzles/Pendant/JewalColors/yellow"); break;
                    case Color.Green:
                        palette[i] = GameManager.Resource.Load<Material>("Prefabs/Puzzles/Pendant/JewalColors/Green"); break;
                    case Color.Blue:
                        palette[i] = GameManager.Resource.Load<Material>("Prefabs/Puzzles/Pendant/JewalColors/Blue"); break;
                    case Color.Purple:
                        palette[i] = GameManager.Resource.Load<Material>("Prefabs/Puzzles/Pendant/JewalColors/Purple"); break;

                    case Color.None:
                        palette[i] = GameManager.Resource.Load<Material>("Prefabs/Puzzles/Pendant/JewalColors/None");
                        palette[i].color = UnityEngine.Color.white;
                        break;
                }
            }
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
