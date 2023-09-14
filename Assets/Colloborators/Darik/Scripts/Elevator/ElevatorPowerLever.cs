using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class ElevatorPowerLever : MonoBehaviour
    {
        private bool isPowered = false;

        public void PowerOn()
        {
            if (!isPowered)
            {
                isPowered = true;
                GameManager.Data.isElevatorPowerOn = true;
                Debug.Log("Elevator Power On");
            }
        }
    }
}
