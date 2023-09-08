using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lee
{
    public interface IinteractableObject
    {
        public void ObjData(string id, Vector3 position, Quaternion rotation);
    }
}
