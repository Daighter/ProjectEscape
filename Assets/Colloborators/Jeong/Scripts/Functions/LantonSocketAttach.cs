using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Jeong
{
    public class LantonSocketAttach : MonoBehaviour
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
