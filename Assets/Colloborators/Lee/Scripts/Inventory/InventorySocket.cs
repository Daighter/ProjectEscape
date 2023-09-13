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
        private GameObject socket;
        private InteratableObject interatableObject;

        private void Awake()
        {
            socketInteractor = GetComponent<XRSocketInteractor>();

            socket = GameManager.Resource.Load<GameObject>("UI/Socket");

            sockets = new List<GameObject>();
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("¿¿æ÷");
        }

        public void OnCreat()
        {
            Instantiate(socket, transform);
            socket.transform.SetAsFirstSibling();
            socketInteractor.attachTransform = socket.transform;
        }

        public void OnRemove()
        {
            Destroy(socket);
        }
    }
}
