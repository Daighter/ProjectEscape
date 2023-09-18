using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Darik
{
    public class MiniRoomClearChecker : MonoBehaviour
    {
        [SerializeField] private bool isDungeonRoomClearMod;
        [SerializeField] private bool isPrisonRoomClearMod;
        [SerializeField] private bool isCaveRoomClearMod;
        [SerializeField] private Stair1FDoorPuzzle stair1FDoorPuzzle;

        [SerializeField] private Image lockedImage;
        [SerializeField] private Image unlockedImage;

        [SerializeField] private bool isDungeonRoom;
        [SerializeField] private bool isPrisonRoom;
        [SerializeField] private bool isCaveRoom;

        private void Start()
        {
            Init();

            CheckDungeonState();
            CheckPrissonState();
            CheckCaveState();
        }

        private void Init()
        {
            Color color = lockedImage.color;
            color.a = 1f;
            lockedImage.color = color;

            color = unlockedImage.color;
            color.a = 0f;
            unlockedImage.color = color;
        }

        private void ChangeClearImage()
        {
            Color color = lockedImage.color;
            color.a = 0f;
            lockedImage.color = color;

            color = unlockedImage.color;
            color.a = 1f;
            unlockedImage.color = color;
        }

        private void CheckDungeonState()
        {
            if (isDungeonRoomClearMod)
            {
                if (isDungeonRoom)
                {
                    stair1FDoorPuzzle.IsDungeonRoomClear = true;
                    stair1FDoorPuzzle.CheckAllClear();
                    ChangeClearImage();
                    Debug.Log("DungeonRoom Claer");
                }
            }
            else
            {
                if (isDungeonRoom && GameManager.Data.isDungeonRoomClear)
                {
                    stair1FDoorPuzzle.IsDungeonRoomClear = true;
                    stair1FDoorPuzzle.CheckAllClear();
                    ChangeClearImage();
                    Debug.Log("DungeonRoom Claer");
                }
            }
        }

        private void CheckPrissonState()
        {
            if (isPrisonRoomClearMod)
            {
                if (isPrisonRoom)
                {
                    stair1FDoorPuzzle.IsPrisonRoomClear = true;
                    stair1FDoorPuzzle.CheckAllClear();
                    ChangeClearImage();
                    Debug.Log("PrisonRoom Claer");
                }
            }
            else
            {
                if (isPrisonRoom && GameManager.Data.isPrisonRoomClear)
                {
                    stair1FDoorPuzzle.IsPrisonRoomClear = true;
                    stair1FDoorPuzzle.CheckAllClear();
                    ChangeClearImage();
                    Debug.Log("PrisonRoom Claer");
                }
            }
        }

        private void CheckCaveState()
        {
            if (isCaveRoomClearMod)
            {
                if (isCaveRoom)
                {
                    stair1FDoorPuzzle.IsCaveRoomClear = true;
                    stair1FDoorPuzzle.CheckAllClear();
                    ChangeClearImage();
                    Debug.Log("CaveRoom Claer");
                }
            }
            else
            {
                if (isCaveRoom && GameManager.Data.isCaveRoomClear)
                {
                    stair1FDoorPuzzle.IsCaveRoomClear = true;
                    stair1FDoorPuzzle.CheckAllClear();
                    ChangeClearImage();
                    Debug.Log("CaveRoom Claer");
                }
            }
        }
    }
}
