using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Jeong
{
    public class SocketAttach : MonoBehaviour
    {
        [SerializeField] XRSocketInteractor lantonSocket;

        private void Start()
        {
            if(lantonSocket == null)
                lantonSocket = GetComponent<XRSocketInteractor>();

            var targetTransform = lantonSocket.startingSelectedInteractable.GetAttachTransform(lantonSocket);
            transform.SetPositionAndRotation(targetTransform.position, targetTransform.rotation);
        }
    }

}
