using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Darik
{
    public class ElevatorFloorViewer : MonoBehaviour
    {
        private TMP_Text floorViewerText;

        private void Awake()
        {
            floorViewerText = GetComponentInChildren<TMP_Text>();
        }

        public void SetFloor(int floor)
        {
            if (floor == -1)
                floorViewerText.text = "B1";
            else if (floor == -2)
                floorViewerText.text = "B2";
        }
    }
}
