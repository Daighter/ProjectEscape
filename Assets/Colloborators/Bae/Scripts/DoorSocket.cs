using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Bae
{
    public class DoorSocket : MonoBehaviour
    {
        [SerializeField] int count;
        
        int runeTrue;
        int socketCount;
        Animator animator;
        public void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if(socketCount == count)
            {
                if(runeTrue == count)
                {
                    animator.SetTrigger("Open");
                }
                else
                {
                    
                }
            }
        }

        public void ONCheckSocket(SelectEnterEventArgs args)
        {
            RuneCheck key =args.interactableObject.transform.GetComponent<RuneCheck>();
            if (key.key)
            {
                runeTrue++;
            }
            socketCount++;
        }


        public void ExitRune(SelectExitEventArgs args)
        {
            socketCount--;
        }
    }
}
