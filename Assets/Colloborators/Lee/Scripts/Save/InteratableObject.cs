using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

namespace Lee
{
    [System.Serializable]
    public class InteratableObject : MonoBehaviour
    {
        public ObjectData objData;
        public string id => gameObject.name;
        public string resourcePath => $"Puzzle/{gameObject.name}";
        public Vector3 position => transform.position;
        public Quaternion rotation => transform.rotation;

        private bool isSokect = false;

        public bool IsSokect { get { return isSokect; } set { isSokect = value; } }
    }

    


}