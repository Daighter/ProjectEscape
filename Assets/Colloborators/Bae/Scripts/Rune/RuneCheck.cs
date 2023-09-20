using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bae
{
    public class RuneCheck : MonoBehaviour
    {
        public string state;
        [SerializeField]
        bool key;

        public bool getKey
        {
            get { return key; }
            set { key = value; }
        }
        private void OnEnable()
        {
            state= gameObject.name+"(Clone)";
        }
    }
}

