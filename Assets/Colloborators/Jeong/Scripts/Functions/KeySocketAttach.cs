using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Jeong
{
    public class KeySocketAttach : MonoBehaviour
    {
        [SerializeField] XRSocketInteractor keySocket;

        private void Start()
        {
            if (keySocket == null)
                keySocket = GetComponent<XRSocketInteractor>();

            var targetTransform = keySocket.startingSelectedInteractable.GetAttachTransform(keySocket);
            transform.SetPositionAndRotation(targetTransform.position, targetTransform.rotation);
        }
    }

}
