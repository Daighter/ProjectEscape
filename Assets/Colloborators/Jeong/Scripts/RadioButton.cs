using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Jeong
{
    public class RadioButton : MonoBehaviour
    {
        XRPokeInteractor interactor;
        Animator anim;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void PressButton()
        {
            anim.SetTrigger("IsPressed");
        }
    }
}

