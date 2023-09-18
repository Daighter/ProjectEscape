using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
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
            isInven = false;
        }

        private void OnEnable()
        {
            xRGrab.selectExited.AddListener(OnSelectExited);
            xRGrab.selectEntered.AddListener(OnSelectEntered);
        }

        private void OnDisable()
        {
            xRGrab.selectExited.RemoveListener(OnSelectExited);
            xRGrab.selectEntered.RemoveListener(OnSelectEntered);
        }

        private void OnSelectExited(SelectExitEventArgs arg)
        {
            if (isInven == false)
            {
                arg.interactableObject.transform.localScale = scale;
            }
            else
            {
                transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
        }

        private void OnSelectEntered(SelectEnterEventArgs arg)
        {
            if (isInven == false)
            {
                arg.interactableObject.transform.localScale = scale;
            }
            else
            {
                transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
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