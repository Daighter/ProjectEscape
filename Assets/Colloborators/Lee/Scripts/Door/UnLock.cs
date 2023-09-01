using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lee
{
    public class UnLock : MonoBehaviour
    {
        private Rigidbody rb;


        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void OnSelectKey()
        {
            rb.freezeRotation = false;
        }
    }
}
