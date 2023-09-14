using Jeong;
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
                    col.enabled = false;
                    animator.SetTrigger("Open");
                    GameManager.Sound.PlayDungeonSound("Door");
                    //GameManager.Data.isDungeonRoomClear = true;
                }
            }
        }
        public void ONCheckSocket(SelectEnterEventArgs args)
        {
            RuneCheck key =args.interactableObject.transform.GetComponent<RuneCheck>();
            GameManager.Sound.PlayDungeonSound("RuneIn");
            if (key.key)
            {
                runeTrue++;
            }
            socketCount++;
        }


        public void ExitRune(SelectExitEventArgs args)
        {
            GameManager.Sound.PlayDungeonSound("RuneOut");
            socketCount--;
        }
    }
}
