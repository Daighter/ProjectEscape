using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Jeong
{
    public class WoodBox : MonoBehaviour
    {
        [SerializeField] GameObject boxKey;
        [SerializeField] GameObject bomb;
        [SerializeField] GameObject effect;
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
            bomb.SetActive(false);
            effect.SetActive(false);
            rigid.constraints = RigidbodyConstraints.FreezeAll;
        }

        public void Open()
        {
            Debug.Log("BoxOpen");
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
                bomb.SetActive(true);
                Destroy(boxKey, 2f);
                Destroy(gameObject, 2f);
                effect.SetActive(true);
            }

        }
    }

}
