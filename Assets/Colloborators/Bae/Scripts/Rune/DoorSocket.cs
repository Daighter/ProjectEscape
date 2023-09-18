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

   
        IEnumerator DoorOpenRoutine()
        {

            yield return new WaitForSeconds(1f);
            col.enabled = false;
            animator.SetTrigger("Open");
            GameManager.Sound.PlayDungeonSound("Door");
            GameManager.Data.DungeonClear();
        }
        public void ONCheckSocket(SelectEnterEventArgs args)
        {
            RuneCheck key =args.interactableObject.transform.GetComponent<RuneCheck>();
            GameManager.Sound.PlayDungeonSound("RuneIn");
            if (key.getKey)
            {
                runeTrue++;
            }
            socketCount++;
            if (socketCount == count)
            {
                if (runeTrue == count)
                {
                    StartCoroutine(DoorOpenRoutine());
                }
            }
           
        }


        public void ExitRune(SelectExitEventArgs args)
        {
            GameManager.Sound.PlayDungeonSound("RuneOut");
            RuneCheck key = args.interactableObject.transform.GetComponent<RuneCheck>();
            if (key.getKey)
            {
                runeTrue--;
            }
            socketCount--;
           
        }
    }
}
