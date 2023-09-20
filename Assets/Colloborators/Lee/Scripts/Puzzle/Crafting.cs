using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Lee
{

    public class Crafting : MonoBehaviour
    {
        private XRSocketInteractor socketInteractor;

        private void Awake()
        {
            socketInteractor = GetComponentInChildren<XRSocketInteractor>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Default"))
            {
                socketInteractor.enabled = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Default"))
            {
                socketInteractor.enabled = false;
            }
        }


    }
}
