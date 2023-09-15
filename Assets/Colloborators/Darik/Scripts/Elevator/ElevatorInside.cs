using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class ElevatorInside : Elevator
    {
        [SerializeField] ElevatorFloorViewer[] floorViewerTexts;
        [SerializeField] private float moveSpeed = 1f;

        [SerializeField] private PlayerTrigger insideTrigger;
        [SerializeField] private PlayerTrigger roofTopTrigger;

        private bool isArrived = true;
        private int curFloor = 0;

        public bool IsArrived { get { return isArrived; } set { isArrived = value; } }

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

        protected override void Start()
        {
            base.Start();

            curFloor = -1;
            transform.position = new Vector3(transform.position.x, -3, transform.position.z);

            StartCoroutine(BadEndingCheckCoroutine());

            if (GameManager.Data.isElevatorPowerOn)
                CurFloor = curFloor;
        }

        public void Move(int targetFloor)
        {
            if (targetFloor == -1)
            {
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
                if (insideTrigger.Player != null)
                    insideTrigger.MoveInElevator(moveSpeed);

                if (transform.position.y >= -3)
                {
                    transform.position = new Vector3(transform.position.x, -3, transform.position.z);
                    CurFloor = -1;
                    isArrived = true;
                }
            }
            else if (targetFloor == -2)
            {
                transform.Translate(Vector3.up * -moveSpeed * Time.deltaTime);
                if (insideTrigger.Player != null)
                    insideTrigger.MoveInElevator(-moveSpeed);

                if (transform.position.y <= -6)
                {
                    transform.position = new Vector3(transform.position.x, -6, transform.position.z);
                    CurFloor = -2;
                    isArrived = true;
                }
            }
        }

        IEnumerator BadEndingCheckCoroutine()
        {
            while (true)
            {
                if (roofTopTrigger.Player != null && CurFloor == -2)
                {
                    StartCoroutine(BadEndingCoroutine());
                    yield break;
                }

                yield return new WaitForSeconds(0.2f);
            }
        }

        IEnumerator BadEndingCoroutine()
        {
            yield return new WaitForSeconds(5f);
            Debug.Log("BadEnd");
        }
    }
}