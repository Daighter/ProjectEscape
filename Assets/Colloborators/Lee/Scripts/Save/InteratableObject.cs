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

        private string objname;
        public string Objname {  get { return objname; } set { objname = value; } }

        public string resourcePath;
        public string ResourcePath { get { return resourcePath; } set { resourcePath = value; } }   
        public Vector3 position=> transform.position;
        public Quaternion rotation => transform.rotation;

        public Vector3 scale => transform.localScale;

        public bool isInven = false;

        private void Awake()
        {
            xRGrab = GetComponent<XRGrabInteractable>();
            xRGrab.selectExited.AddListener(OnSelectExited);
        }

        private void OnSelectExited(SelectExitEventArgs args)
        {
            if (isInven == true)
                args.interactableObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            if (isInven == false)
                args.interactableObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                isInven = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                isInven = false;
            }
        }

        public void Arem()
        {
            Debug.Log("호버응애");
        }
    }
}