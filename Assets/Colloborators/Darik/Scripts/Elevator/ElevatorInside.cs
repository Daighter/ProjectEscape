using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class ElevatorInside : Elevator
    {
        [SerializeField] ElevatorFloorViewer[] floorViewerTexts;
        [SerializeField] private float moveSpeed = 1f;

        private PlayerTrigger playerTrigger;
        public bool isArrived = true;
        private int curFloor = 0;

        public int CurFloor
        {
            get { return curFloor; }
            set
            {
                curFloor = value;
                foreach (ElevatorFloorViewer text in floorViewerTexts)
                {
                    text.SetFloor(value);
                }
            }
        }

        private void Awake()
        {
            playerTrigger = GetComponentInChildren<PlayerTrigger>();
        }

        protected override void Start()
        {
            base.Start();

            CurFloor = -1;
            transform.position = new Vector3(transform.position.x, -3, transform.position.z);
        }

        public void Move(int targetFloor)
        {
            if (targetFloor == -1)
            {
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
                if (playerTrigger.Player != null)
                    playerTrigger.MoveInElevator(moveSpeed);

                if (transform.position.y >= -3)
                {
                    transform.position = new Vector3(transform.position.x, -3, transform.position.z);
                    curFloor = -1;
                    isArrived = true;
                }
            }
            else if (targetFloor == -2)
            {
                transform.Translate(Vector3.up * -moveSpeed * Time.deltaTime);
                if (playerTrigger.Player != null)
                    playerTrigger.MoveInElevator(-moveSpeed);

                if (transform.position.y <= -6)
                {
                    transform.position = new Vector3(transform.position.x, -6, transform.position.z);
                    CurFloor = -2;
                    isArrived = true;
                }
            }
        }
    }
}
