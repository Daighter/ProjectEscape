using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class FacilityDoor : MonoBehaviour
    {
        [SerializeField] private bool debug;
        [SerializeField] private float rotSpeed = 1f;

        private const float maxOpenAngle = -90f;

        private void Start()
        {
            if (GameManager.Data.isFacilityDoorOpen)
                transform.localRotation = Quaternion.Euler(0f, maxOpenAngle, 0f);
            else
                transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }

        public void OpenFacilityDoor()
        {
            if (!GameManager.Data.isFacilityDoorOpen)
            {
                GameManager.Data.isFacilityDoorOpen = true;
                StartCoroutine(OpenTheDoorCoroutine());
            }
        }

        IEnumerator OpenTheDoorCoroutine()
        {
            Debug.Log("FacilityRoom Opened");
            while (true)
            {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, maxOpenAngle, 0f), rotSpeed * 0.01f);
                if (transform.localRotation == Quaternion.Euler(0f, maxOpenAngle, 0f))
                {
                    if (debug)
                        Debug.Log("Coroutine Break");
                    yield break;
                }

                yield return null;
            }
        }
    }
}
