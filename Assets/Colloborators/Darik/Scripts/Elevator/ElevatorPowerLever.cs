using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class ElevatorPowerLever : MonoBehaviour
    {
        [SerializeField] private bool debug;
        [SerializeField] private UnityEngine.XR.Content.Interaction.XRLever XRLever;

        private void Start()
        {
            if (GameManager.Data.isFacilityDoorOpen)
                XRLever.value = true;
        }

        public void PowerOn()
        {
            if (!GameManager.Data.isElevatorPowerOn)
            {
                GameManager.Data.isElevatorPowerOn = true;

                GameManager.Sound.PlayMainRoomSound("ElevatorPowerOn");
                if (debug)
                    Debug.Log("Elevator Power On");
            }
        }
    }
}
