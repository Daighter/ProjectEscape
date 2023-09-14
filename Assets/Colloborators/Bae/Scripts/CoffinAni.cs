using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bae
{
    public class CoffinAni : MonoBehaviour
    {
        Animator animator;
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void CoffinOpen()
        {
            animator.SetBool("Open", true);
        }
        public void CoffinClose()
        {
            animator.SetBool("Open", false);
        }
    }
}

