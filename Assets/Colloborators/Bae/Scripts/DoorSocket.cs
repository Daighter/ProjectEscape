using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Bae
{
    public class DoorSocket : MonoBehaviour
    {
        [SerializeField] int count;
        [SerializeField] Collider col;
        AudioSource audio;
        
        int runeTrue;
        int socketCount;
        Animator animator;
        public void Awake()
        {
            audio = GetComponent<AudioSource>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if(socketCount == count)
            {
                if(runeTrue == count)
                {
                    col.enabled = false;
                    animator.SetTrigger("Open");
                    gameObject.GetComponent<AudioSource>().Play();
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
