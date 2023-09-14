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

        private void Awake()
        {
            hinge = GetComponent<HingeJoint>();
            rb = GetComponent<Rigidbody>();
            openDoorLimits = hinge.limits;
            closedDoorLimits.min = 0.0f;
            closedDoorLimits.max = 0.0f;
            hinge.limits = closedDoorLimits;
           
        }
        
        public void OnSelectKey()
        {
            rb.isKinematic = false;
            hinge.limits = openDoorLimits;
            GameManager.Data.PrisonClear();
        }
    }
}
