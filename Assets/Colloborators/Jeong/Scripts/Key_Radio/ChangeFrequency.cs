using System.Collections;
using UnityEngine;

namespace Jeong
{
    public class ChangeFrequency : MonoBehaviour
    {
        [SerializeField] GameObject Dial;

        [SerializeField] Transform frequencyPointer;

        [SerializeField] Radio radio;
        [SerializeField] RadioDial radioDial;

        [SerializeField] public float basePos;

        [SerializeField] public bool ch180 = false;

        private void Awake()
        {
            radioDial = GetComponent<RadioDial>();
            frequencyPointer = GameObject.Find("FrequencyPointer").GetComponent<Transform>();
        }

        private void Start()
        {
            ch180 = false;
        }

        private void FixedUpdate()
        {
            SelectChannel();
        }

        private void SelectChannel()
        {
            if(radio.radioPlay)
            {
                if (0.55f <= basePos && basePos < 0.60f)
                {
                    ch180 = true;
                    radioDial.enabled = false;
                    frequencyPointer.transform.localPosition = new Vector3(0.5f, 0.57f, 2f);
                }

                else
                {
                    ch180 = false;
                    basePos = radioDial.value;
                    frequencyPointer.transform.localPosition = new Vector3(0.5f, basePos, 2f);
                }
            }
            else if (!radio.radioPlay)
                return;

            
        }
    }

}
