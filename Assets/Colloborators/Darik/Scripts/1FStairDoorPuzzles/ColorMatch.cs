using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class ColorMatch : MonoBehaviour
    {
        [SerializeField] private Stair1FDoorPuzzle stair1FDoorPuzzle;
        [SerializeField] private ColorChanger[] colorChangers;

        private bool isClear = false;

        private void Start()
        {
            StartCoroutine(CheckCoroutine());
        }

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
                stair1FDoorPuzzle.IsColorMatchClear = true;
                stair1FDoorPuzzle.CheckAllClear();
                Debug.Log("ColorMatch Clear");
            }
        }

        IEnumerator CheckCoroutine()
        {
            yield return new WaitForSeconds(0.5f);
            CheckAnswer();
            if (isClear && !GameManager.Data.is1FStairDoorOpen)
                stair1FDoorPuzzle.CheckAllClear();
        }
    }
}
