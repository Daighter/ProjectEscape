using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


namespace Bae
{
    public class SocketKey : MonoBehaviour
    {
        [SerializeField] GameObject socketKey;
        public string socketKeyName;

        private void OnEnable()
        {
            socketKeyName = socketKey.name;
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

