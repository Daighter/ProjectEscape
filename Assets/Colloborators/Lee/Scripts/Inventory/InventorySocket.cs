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
    public class InventorySocket : XRGridSocket
    {
        private XRSocketInteractor socketInteractor;
        private List<GameObject> sockets;
        private GameObject socket;
        private InteratableObject interatableObject;

        protected override void Awake()
        {
            base.Awake();
            socketInteractor = GetComponent<XRSocketInteractor>();

            socket = GameManager.Resource.Load<GameObject>("UI/Socket");

            sockets = new List<GameObject>();

            //socketInteractor.selectEntered.AddListener(OnSave);
        }

        //public void OnSave(SelectEnterEventArgs arg)
        //{
        //    GameManager.ObjM.InTheInventory();
        //}
        //
    }
}
