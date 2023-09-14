using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class ColorMatch : MonoBehaviour
    {
        [SerializeField] private ColorChanger[] colorChangers;
        [SerializeField] private GameObject stair1FDoor;

        private bool isClear = false;

        public void CheckAnswer()
        {
            for (int i = 0; i < 4; i++)
            {
                if (GameManager.Data.colors[i] != (DataManager.Color)colorChangers[i].CurIndex)
                    return;
            }

            if (!isClear)
            {
                isClear = true;
                stair1FDoor.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                Debug.Log("Open1FStairDoor");
            }
        }
    }
}
