using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Darik
{
    public class MiniRoomClearChecker : MonoBehaviour
    {
        [SerializeField] private Image lockedImage;
        [SerializeField] private Image unlockedImage;

        [SerializeField] private bool isDungeonRoom;
        [SerializeField] private bool isPrisonRoom;
        [SerializeField] private bool isCaveRoom;

        private void Start()
        {
            Init();

            if (isDungeonRoom && GameManager.Data.isDungeonRoomClear)
                ChangeClearImage();

            else if (isPrisonRoom && GameManager.Data.isPrisonRoomClear)
                ChangeClearImage();

            else if (isCaveRoom && GameManager.Data.isCaveRoomClear)
                ChangeClearImage();
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

            Debug.Log("MiniRoom Claer");
        }
    }
}
