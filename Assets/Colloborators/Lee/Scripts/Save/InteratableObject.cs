using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.GraphicsBuffer;

namespace Lee
{
    [System.Serializable]
    public class InteratableObject : MonoBehaviour
    {
        private XRGrabInteractable xRGrab;

        public string resourcePath;
        public Vector3 position=> transform.position;
        public Quaternion rotation => transform.rotation;

        public Vector3 scale => transform.localScale;

        private bool isInven = false;

        public bool IsInven { get { return isInven; } set { isInven = value; } }

        private void Awake()
        {
            xRGrab = GetComponent<XRGrabInteractable>();
            xRGrab.selectExited.AddListener(OnSelectExited);
            xRGrab.selectEntered.AddListener(OnSelectEntered);
        }

        private void OnEnable()
        {
            resourcePath = $"Puzzle/{gameObject.name}";
        }

        private void OnSelectEntered(SelectEnterEventArgs args)
        {
            if (IsInven == false)
                args.interactableObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        private void OnSelectExited(SelectExitEventArgs args)
        {
            if (IsInven == true)
                args.interactableObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                IsInven = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                IsInven = false;
            }
        }
    }
}