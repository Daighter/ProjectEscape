using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Jeong
{
    public class WoodBox : MonoBehaviour
    {
        Rigidbody rigid;
        XRGrabInteractable grabInteractable;

        private void Awake()
        {
            rigid = GetComponent<Rigidbody>();
            grabInteractable = GetComponent<XRGrabInteractable>();
        }

        private void Start()
        {
            grabInteractable.enabled = false;
            rigid.constraints = RigidbodyConstraints.FreezeAll;
            

        }



        public void Open()
        {
            Debug.Log("Open");
            grabInteractable.enabled = true;
            if(!grabInteractable.enabled)
            {
                Debug.Log("Open/RigidbodyConstraints.FreezeAll");
                return;
            }

            else if (grabInteractable.enabled) 
            {
                Debug.Log("Open/RigidbodyConstraints.None");
                rigid.constraints = RigidbodyConstraints.None;
            }
            
        }
    }

}
