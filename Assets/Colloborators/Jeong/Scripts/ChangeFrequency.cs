using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Jeong
{
    public class ChangeFrequency : MonoBehaviour
    {

        [SerializeField] GameObject Dial;        
        [SerializeField] GameObject ExitPoint;
        [SerializeField] GameObject RescueMessage;
        [SerializeField] Transform frequencyPointer;

        [SerializeField] float basePos;
        
        RadioDial radioDial;

        bool ch180 = false;

        private void Awake()
        {
            radioDial = GetComponent<RadioDial>();
            frequencyPointer = GameObject.Find("Frequency Pointer").GetComponent<Transform>();
        }

        private void Start()
        {
            ch180 = false;
            //RescueMessage.SetActive(false);
            ExitPoint.SetActive(false);
        }

        private void Update()
        {
            StartCoroutine(ChangePointerPositionRoutine());
        }

        private IEnumerator ChangePointerPositionRoutine()
        {
            basePos = radioDial.value;
            frequencyPointer.transform.localPosition = new Vector3(0.5f, basePos, 2f);
            SelectChannelRoutine();
            yield return new WaitForFixedUpdate();
        }

        private void SelectChannelRoutine()
        {
            if (!radioDial.enabled)
                return;

            else if (0.55f <= basePos&&basePos < 0.60f)
            {
                ch180 = true;
                if(ch180)
                {
                    //RescueMessage.SetActive(true);
                    ExitPoint.SetActive(true);
                }
            }
            else
            {
                ch180 = false;
                ExitPoint.SetActive(false);
            }
        }
    }

}
