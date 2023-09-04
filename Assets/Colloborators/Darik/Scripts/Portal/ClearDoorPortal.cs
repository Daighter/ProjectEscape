using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class ClearDoorPortal : MonoBehaviour
    {
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private string sceneName;

        private void OnTriggerEnter(Collider other)
        {
            if (playerLayer.Contain(other.gameObject.layer))
                GameManager.Scene.LoadScene(sceneName);
        }
    }
}