using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Lee
{
    public class KeyHolder : XRSocketInteractor
    {
        XRSocketInteractor socketInteractor;
        GameObject keyOb;
        private bool isKey;

        protected override void Awake()
        {
            base.Awake();
            keyOb = GameObject.Find("JaillKey");
        }

        private void KeyChecker()
        {
            socketInteractor.allowSelect = true;
        }
    }
}

