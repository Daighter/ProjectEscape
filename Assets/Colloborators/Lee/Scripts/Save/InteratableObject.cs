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

        private Vector3 scale;

        private bool isInven;

        public bool IsInven { get {  return isInven; } set {  isInven = value; } }

        private void Awake()
        {
            xRGrab = GetComponent<XRGrabInteractable>();
            scale = transform.localScale;
        }

        private void OnEnable()
        {
            xRGrab.selectExited.AddListener(OnSelectExited);
        }

        private void OnDisable()
        {
            xRGrab.selectExited.RemoveListener(OnSelectExited);
        }

        private void OnSelectExited(SelectExitEventArgs args)
        {
            if (isInven == true)
            {
                isInven = true;
                args.interactableObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
                
            if (isInven == false)
            {
                isInven = false;
                args.interactableObject.transform.localScale = scale;
            }
        }

       private void OnTriggerEnter(Collider other)
       {
           if (other.gameObject.layer == LayerMask.NameToLayer("UI"))
           {
               isInven = true;
            }
       }
       
       private void OnTriggerStay(Collider other)
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

        public void OnInventory()
        {
            isInven = true;
        }

        public void OutInventory()
        {
            isInven = false;
        }
    }
}