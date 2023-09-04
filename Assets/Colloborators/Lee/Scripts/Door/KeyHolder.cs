using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Lee
{
    public class KeyHolder : XRSocketInteractor
    {
        XRSocketInteractor socketInteractor;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void OnSelectEntering(SelectEnterEventArgs args)
        {
            base.OnSelectEntering(args);
            if(args.interactable.gameObject.name == "JaillKey")
            {
                socketInteractor.allowSelect = true;
            }

        }
    }
}

