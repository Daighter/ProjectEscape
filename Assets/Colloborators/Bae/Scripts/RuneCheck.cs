using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bae
{
    public class RuneCheck : MonoBehaviour
    {
        public string state;
        public bool key;
        private void OnEnable()
        {
            state= gameObject.name;
        }
    }
}

