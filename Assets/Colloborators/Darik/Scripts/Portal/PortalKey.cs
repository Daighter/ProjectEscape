using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class PortalKey : MonoBehaviour
    {
        [SerializeField] protected string sceneName;

        public void LoadMiniRoomScene()
        {
            if (sceneName != null)
                GameManager.Scene.LoadScene(sceneName);
        }
    }
}
