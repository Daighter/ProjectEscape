using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class Elevator : MonoBehaviour
    {
        [SerializeField] protected Transform leftDoor;
        [SerializeField] protected Transform rightDoor;
        [SerializeField] protected float doorMoveSpeed = 1f;

        [SerializeField] protected Transform closePosition;
        [SerializeField] protected Transform openLPosition;
        [SerializeField] protected Transform openRPosition;

        public bool isClosed;

        protected virtual void Start()
        {
            leftDoor.position = closePosition.position;
            rightDoor.position = closePosition.position;
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
            leftDoor.Translate(Vector3.right * doorMoveSpeed * Time.deltaTime);
            rightDoor.Translate(Vector3.right * -doorMoveSpeed * Time.deltaTime);

            if (leftDoor.position.x >= openLPosition.position.x)
            {
                leftDoor.position = openLPosition.position;
                rightDoor.position = openRPosition.position;
                isClosed = false;
            }
        }

        private void CloseMovement()
        {
            leftDoor.Translate(Vector3.right * -doorMoveSpeed * Time.deltaTime);
            rightDoor.Translate(Vector3.right * doorMoveSpeed * Time.deltaTime);

            if (leftDoor.position.x <= closePosition.position.x)
            {
                leftDoor.position = closePosition.position;
                rightDoor.position = closePosition.position;
                isClosed = true;
            }
        }
    }
}
