using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class Elevator : MonoBehaviour
    {
        [SerializeField] protected Transform leftDoor;
        [SerializeField] protected Transform rightDoor;
        [SerializeField] private float moveSpeed = 1f;

        private const float closeXPoint = -1.246985f;
        private const float OpenXPointL = -0.546985f;
        private const float OpenXPointR = -1.946985f;
        private bool isClosed;

        public bool IsClosed { get { return isClosed; } }

        protected virtual void Start()
        {
            leftDoor.position = new Vector3(closeXPoint, leftDoor.position.y, leftDoor.position.z);
            rightDoor.position = new Vector3(closeXPoint, rightDoor.position.y, rightDoor.position.z);
            isClosed = true;
        }

        public IEnumerator OpenCoroutine()
        {
            while (isClosed)
            {
                OpenMovement();
                yield return null;
            }
        }

        public IEnumerator CloseCoroutine()
        {
            while (!isClosed)
            {
                CloseMovement();
                yield return null;
            }
        }

        private void OpenMovement()
        {
            leftDoor.Translate(Vector3.right * -moveSpeed * Time.deltaTime, Space.World);
            rightDoor.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);

            if (leftDoor.position.x <= OpenXPointL)
            {
                leftDoor.position = new Vector3(OpenXPointL, leftDoor.position.y, leftDoor.position.z);
                rightDoor.position = new Vector3(OpenXPointR, rightDoor.position.y, rightDoor.position.z);
                isClosed = false;
            }
        }

        private void CloseMovement()
        {
            leftDoor.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
            rightDoor.Translate(Vector3.right * -moveSpeed * Time.deltaTime, Space.World);

            if (leftDoor.position.x >= closeXPoint)
            {
                leftDoor.position = new Vector3(closeXPoint, leftDoor.position.y, leftDoor.position.z);
                rightDoor.position = new Vector3(closeXPoint, rightDoor.position.y, rightDoor.position.z);
                isClosed = true;
            }
        }
    }
}
