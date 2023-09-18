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
        private void Awake()
        {
            socketInteractor = GetComponent<XRSocketInteractor>();
        }

        private void OnEnable()
        {
            socketInteractor.selectEntered.AddListener(OnIven);
            socketInteractor.selectExited.AddListener(OutInven);
        }
        
        private void OnDisable()
        {
             socketInteractor.selectEntered.RemoveListener(OnIven);
             socketInteractor.selectExited.RemoveListener(OutInven);
        }
         public void OnIven(SelectEnterEventArgs arg) 
         {
             arg.interactableObject.transform.gameObject.GetComponent<InteratableObject>().isInven = true;
         }
        
        public void OutInven(SelectExitEventArgs arg)
        {
            arg.interactableObject.transform.gameObject.GetComponent<InteratableObject>().isInven = false;
        }
    }
}
