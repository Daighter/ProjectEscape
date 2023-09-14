using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Jeong
{
    public class Radio : MonoBehaviour
    {
        [SerializeField] GameObject radioLight;
        [SerializeField] GameObject radioPointer;
        [SerializeField] GameObject ExitPoint;
        [SerializeField] GameObject RescueMessage;

        [SerializeField] ChangeFrequency changeFrequency;
        [SerializeField] RadioDial radioDial;

        [SerializeField] public bool radioPowerOn;
        [SerializeField] public bool radioPlay;

       
        private void Start()
        {
            radioPowerOn = false;
            radioPlay = false;
            RescueMessage.SetActive(false);
            ExitPoint.SetActive(false);
        }
        private void Update()
        {
            StartCoroutine(ChangeRadioStateRoutine());
        }

        private IEnumerator ChangeRadioStateRoutine()
        {
            RadioPlayState();
            yield return new WaitForFixedUpdate();
        }

        public void RadioPowerOn()
        {
            radioPowerOn = true;
        }
        
        public void RadioPlay()
        {
            radioPlay = true;
        }
        

        public void RadioPlayState()
        {

            if (!radioPowerOn && !radioPlay)
            {
                radioPointer.SetActive(false);
                return;
            }

            else if (!radioPowerOn && radioPlay)
            {
                return;
            }

            else if (radioPowerOn)
            {
                radioPointer.SetActive(true);
                return;
                // 애니메이션 or 이펙트 재생
            }


            else if (radioPlay && !changeFrequency.ch180)
            {
                Debug.Log($"{changeFrequency.ch180}");
                RescueMessage.SetActive(false);
                ExitPoint.SetActive(false);
                return;
            }


            else if (radioPlay && changeFrequency.ch180)
            {
                Debug.Log($"{changeFrequency.ch180}");
                RescueMessage.SetActive(true);
                ExitPoint.SetActive(true);
                return;
            }

            else
            {
                RescueMessage.SetActive(false);
                ExitPoint.SetActive(false);
                return;
            }
                
        }
    }
}

