using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jeong
{
    public class LantonStandNameKey : MonoBehaviour
    {
        public string standName;
        
        public void OnHang()
        {
            standName = transform.parent.name;
        }

        
    }
}
