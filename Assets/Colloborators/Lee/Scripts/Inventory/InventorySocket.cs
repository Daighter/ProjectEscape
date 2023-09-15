using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEditor.Progress;

namespace Lee
{
    public class InventorySocket : MonoBehaviour
    {
        private XRSocketInteractor socketInteractor;
        private List<GameObject> sockets;
        private GameObject item;
        private InteratableObject interatableObject;

        //protected override void Awake()
        //{
        //    base.Awake();
        //    socketInteractor = GetComponent<XRSocketInteractor>();
        //    sockets = new List<GameObject>();
        //}

        private void Awake()
        {
            socketInteractor = GetComponent<XRSocketInteractor>();
            sockets = new List<GameObject>();
        }

        private void OnEnable()
        {
            socketInteractor.hoverEntered.AddListener(OnInven);
            socketInteractor.hoverExited.AddListener(OutInven);
        }

        private void OnDisable()
        {
            socketInteractor.hoverEntered.RemoveListener(OnInven);
            socketInteractor.hoverExited.RemoveListener(OutInven);
        }

        public void OnInven(HoverEnterEventArgs arg)
        {
            arg.interactableObject.transform.gameObject.GetComponent<InteratableObject>().Smaller();
        }

        public void OutInven(HoverExitEventArgs arg)
        {
            arg.interactableObject.transform.gameObject.GetComponent<InteratableObject>().Largeer();
        }
    }
}
