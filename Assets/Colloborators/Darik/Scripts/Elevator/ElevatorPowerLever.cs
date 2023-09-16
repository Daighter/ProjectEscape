using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class ElevatorPowerLever : MonoBehaviour
    {
        [SerializeField] private bool debug;

        private bool isPowered = false;

        public void PowerOn()
        {
            if (!isPowered)
            {
                isPowered = true;
                GameManager.Data.isElevatorPowerOn = true;

                GameManager.Sound.PlayMainRoomSound("ElevatorPowerOn");
                if (debug)
                    Debug.Log("Elevator Power On");
            }
        }
    }
}
