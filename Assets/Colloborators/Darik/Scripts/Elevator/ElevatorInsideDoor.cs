using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class ElevatorInsideDoor : Elevator
    {
        [SerializeField] private float moveSpeed = 1f;

        private PlayerTrigger playerTrigger;
        public bool isAlived = true;
        private int curFloor = 0;

        public int CurFloor { get { return curFloor; } }

        private void Awake()
        {
            playerTrigger = GetComponentInChildren<PlayerTrigger>();
        }

        protected override void Start()
        {
            base.Start();

            curFloor = -1;
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
                    isAlived = true;
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
                    curFloor = -2;
                    isAlived = true;
                }
            }
        }
    }
}
