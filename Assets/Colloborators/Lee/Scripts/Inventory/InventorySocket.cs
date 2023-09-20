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
           socketInteractor.selectEntered.AddListener(OnInven);
           socketInteractor.selectExited.AddListener(OutInven);
           socketInteractor.hoverEntered.AddListener(OnHover);
           socketInteractor.hoverExited.AddListener(OutHover);
       }

        private void OnDisable()
        {
           socketInteractor.selectEntered.RemoveListener(OnInven);
           socketInteractor.selectExited.RemoveListener(OutInven);
           socketInteractor.hoverEntered.RemoveListener(OnHover);
           socketInteractor.hoverExited.RemoveListener(OutHover);
        }

       public void OnHover(HoverEnterEventArgs arg)
       {
           arg.interactableObject.transform.gameObject.GetComponent<InteratableObject>().OnInventory();
       }
       
       public void OutHover(HoverExitEventArgs arg)
       {
           arg.interactableObject.transform.gameObject.GetComponent<InteratableObject>().OutInventory();
       }

       public void OnInven(SelectEnterEventArgs arg)
       {
            arg.interactableObject.transform.gameObject.GetComponent<InteratableObject>().OnInventory();
       }
       
       public void OutInven(SelectExitEventArgs arg)
       {
           arg.interactableObject.transform.gameObject.GetComponent<InteratableObject>().OutInventory();
       }
    }
}
