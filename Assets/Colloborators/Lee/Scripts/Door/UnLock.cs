using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Lee
{
    public class UnLock : MonoBehaviour
    {
        JointLimits openDoorLimits;
        JointLimits closedDoorLimits;
        private HingeJoint hinge;
        private Rigidbody rb;
        private XRGrabInteractable xRGrab;
        private XRSocketInteractor socketInteractor;

        private void Awake()
        {
            socketInteractor = GetComponentInChildren<XRSocketInteractor>();
            hinge = GetComponent<HingeJoint>();
            rb = GetComponent<Rigidbody>();
            openDoorLimits = hinge.limits;
            closedDoorLimits.min = 0.0f;
            closedDoorLimits.max = 0.0f;
            hinge.limits = closedDoorLimits;
        }

        private void OnEnable()
        {
            socketInteractor.selectEntered.AddListener(OnOpen);
        }

        private void OnDisable()
        {
            socketInteractor.selectEntered.RemoveListener(OnOpen);
        }

        public void OnSelectKey()
        {
            rb.isKinematic = false;
            hinge.limits = openDoorLimits;
        }
            

        public void OnOpen(SelectEnterEventArgs arg)
        {
            arg.interactableObject.transform.gameObject.GetComponent<Collider>().enabled = false;
        }

        public void OnRoomClaer()
        {
            GameManager.Data.PrisonClear();
        }
    }
}
