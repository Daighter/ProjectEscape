using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


namespace Bae
{
    public class SocketKey : MonoBehaviour
    {
        [SerializeField] GameObject socketKey;
        [SerializeField] string socketKeyName;

        private void Start()
        {
            socketKeyName = socketKey.transform.GetChild(0).name;
        }

        public void OnCheckRunes(SelectEnterEventArgs args)
        {
            RuneCheck rune = args.interactableObject.transform.GetComponent<RuneCheck>();
            if(socketKeyName == rune.state)
            {
                rune.getKey = true;

            }
            else
            {
                rune.getKey=false;
            }
        }
    }
}

