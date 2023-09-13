using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Jeong
{
    public class RadioButton : MonoBehaviour
    {
        Animator anim;
        int buttonCount = 0;

         [SerializeField] Radio radio;

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void Start()
        {
            anim.SetBool("IsPressed", false);
        }


        public void PressPlayButton()
        {
            if (radio.radioPowerOn)
            {
                if (buttonCount == 0)
                {
                    anim.SetBool("IsPressed", true);
                    buttonCount += 1;
                    radio.radioPlay = true;
                }

                else if (buttonCount == 1)
                {
                    anim.SetBool("IsPressed", false);
                    buttonCount -= 1;
                    radio.radioPlay = false;
                }
            }
            else
                return;
        }
      
    }
}

