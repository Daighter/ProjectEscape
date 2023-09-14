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

        public bool radioPowerOn;
        public bool radioPlay;
        public bool isCaveClear = false;
       
        private void Start()
        {
            radioPowerOn = false;
            radioPlay = false;
            RescueMessage.SetActive(false);
            ExitPoint.SetActive(false);
        }
        private void FixedUpdate()
        {
            RadioPlayState();
        }
        
        public void RadioPowerOn()
        {
            radioPowerOn = true;
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

            else if (radioPowerOn && !radioPlay)
            {
                radioPointer.SetActive(true);
                return;
                // 애니메이션 or 이펙트 재생
            }

            else if (radioPlay && !changeFrequency.ch180)
            {
                RescueMessage.SetActive(false);
                ExitPoint.SetActive(false);
                return;
            }

            else if (radioPlay && changeFrequency.ch180)
            {
                RescueMessage.SetActive(true);
                ExitPoint.SetActive(true);
                GameManager.Data.CaveClear();
                return;
            }
        }
    }
}

