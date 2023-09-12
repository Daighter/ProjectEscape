using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Lee
{
    public class InventorySocket : MonoBehaviour
    {
        private XRSocketInteractor socketInteractor;
        private GameObject socket;
        private List<GameObject> sockets;

        private void Awake()
        {
            socketInteractor = GetComponent<XRSocketInteractor>();
            socket = GameManager.Resource.Load<GameObject>("UI/Socket");
            sockets = new List<GameObject>();

            socketInteractor.hoverEntered.AddListener(OnHoverEnterd);
            socketInteractor.hoverExited.AddListener(OnHoverExited);
            
            //socketInteractor.selectEntered.AddListener(OnSelectEntering);
            socketInteractor.selectExited.AddListener(OnSelectExiting);
        }

        private void OnHoverExited(HoverExitEventArgs arg0)
        {
            Destroy(socket);
        }

        private void OnHoverEnterd(HoverEnterEventArgs arg0)
        {
            GameManager.Resource.Instantiate(socket, transform);
            socketInteractor.attachTransform = socket.transform;
        }

        private void CreatSocket()
        {
            sockets.Add(socket);
        }

        //private void OnSelectEntering(SelectEnterEventArgs arg0)
        //{
        //    GameManager.Resource.Instantiate(socket, transform);
        //    socketInteractor.attachTransform = socket.transform;
        //}

        private void OnSelectExiting(SelectExitEventArgs arg0)
        {
            Destroy(socket);
        }
    }
}
