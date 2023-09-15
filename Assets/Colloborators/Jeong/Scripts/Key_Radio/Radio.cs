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
        [SerializeField] GameObject radioKey;

        [SerializeField] ChangeFrequency changeFrequency;

        Rigidbody rb;

        public bool radioPowerOn;
        public bool radioPlay;
        public bool isRadioClear;

        [SerializeField] AudioSource[] caveRadioAudio;

        private string[] key = new string[3];

        private void Awake()
        {
            Keys();
            for (int i = 0; i < key.Length; i++)
            {
                GameManager.Sound.AddCaveSound(key[i], caveRadioAudio[i]);
            }

        }

        private void Keys()
        {
            key[0] = "RadioDialSound";
            key[1] = "RadioClearSound";
            key[2] = "RadioPowerOnSound";
        }

        private void Start()
        {
            rb = radioKey.GetComponent<Rigidbody>();
            isRadioClear = false;
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
            GameManager.Sound.PlayCaveSound("RadioPowerOnSound");
            
        }

        public void RadioPlayState()
        {
            if(!isRadioClear)
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
                    GameManager.Sound.PlayCaveSound("RadioDialSound");
                    RescueMessage.SetActive(false);
                    ExitPoint.SetActive(false);
                    return;
                }

                else if (radioPlay && changeFrequency.ch180)
                {
                    isRadioClear = true;
                    if (isRadioClear)
                    {
                        GameManager.Sound.PlayCaveSound("RadioClearSound");
                        RescueMessage.SetActive(true);
                        ExitPoint.SetActive(true);
                        GameManager.Data.isCaveLantonClear = true;
                        GameManager.Data.CaveClear();
                        return;
                    }
                }

               
            }
        }
    }
}

