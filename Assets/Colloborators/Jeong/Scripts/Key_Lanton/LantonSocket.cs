using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jeong
{
    public class LantonSocket : MonoBehaviour
    {
        [SerializeField] LantonPositionController lantonPositionController;

        public bool isSocketed = false;

        public void Socketed()
        {
            if(!isSocketed) 
            {
                isSocketed = true;
                Check();
            }
        }

        public void UnSocketed()
        {
            if (!isSocketed)
                return;

            else if (isSocketed)
            {
                isSocketed = false;
            }
            
        }

        public void Check()
        {
            lantonPositionController.Check1();
            lantonPositionController.Check2();
            lantonPositionController.Check3();
            lantonPositionController.LantonClear();
        }
    }
}
