using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jeong
{
    public class RadioLight : MonoBehaviour
    {
        [SerializeField] Material[] radionLingtMats = new Material[3];
        [SerializeField] Material radioMats;
        [SerializeField] ChangeFrequency changeFrequency;
        
        [SerializeField] Radio radio;

        private void FixedUpdate()
        {
            LightState();
        }

        public void LightState()
        {
            if (!radio.radioPowerOn && !radio.radioPlay)
            {
                gameObject.GetComponent<MeshRenderer>().material = radionLingtMats[0];
                return;
            }
          
            else if (!radio.radioPowerOn && radio.radioPlay)
            {
                return;
            }

            else if (radio.radioPowerOn && !radio.radioPlay)
            {
                gameObject.GetComponent<MeshRenderer>().material = radionLingtMats[1];
                return;
            }

            else if (radio.radioPlay && !changeFrequency.ch180)
            {
                gameObject.GetComponent<MeshRenderer>().material = radionLingtMats[2];
                return;
            }

            else if (radio.radioPlay && changeFrequency.ch180)
            {
                gameObject.GetComponent<MeshRenderer>().material = radionLingtMats[2];
                return;
            }
            
        }
    }
}
