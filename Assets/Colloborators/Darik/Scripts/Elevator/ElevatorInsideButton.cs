using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class ElevatorInsideButton : MonoBehaviour
    {
        [SerializeField] private ElevatorController elevatorController;

        public void WantToGoB1()
        {
            elevatorController.MoveCommand(-1);
        }

        public void WantToGoB2()
        {
            elevatorController.MoveCommand(-2);
        }
    }
}
