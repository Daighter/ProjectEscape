using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        public string id;
        public string resourcePath;
        public Vector3 position;
        public Quaternion rotation;

        public Vector3 scale;

        private bool isInven = false;

        public bool IsInven { get { return isInven; } set { isInven = value; } }

        private void Awake()
        {
            id = gameObject.name;
            resourcePath = $"Puzzle/{gameObject.name}";
            position = transform.position;
            rotation = transform.rotation;
            scale = transform.localScale;
            xRGrab = GetComponent<XRGrabInteractable>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                IsInven = true;
            }
        }

        public void OnInven()
        {
            if(IsInven==true)
            {
                scale = new Vector3(0.005f, 0.005f, 0.005f);
            }
        }
    }
}