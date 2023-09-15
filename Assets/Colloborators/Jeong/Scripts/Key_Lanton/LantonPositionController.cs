
using UnityEngine;

namespace Jeong
{
    public class LantonPositionController : MonoBehaviour
    {
        [SerializeField] LantonLinkGimmick lantonLinkGimmick;
        [SerializeField] LantonStandNameKey lantonStandNameKey;
        [SerializeField] LantonPositionNum lantonPositionNum;

        public GameObject[] lantonStand = new GameObject[12];
        public GameObject[] lantonStandKey = new GameObject[3];

        bool isFstPosition = false;
        bool isSecPosition = false;
        bool isTrdPosition = false;

        private void Start()
        {
            for (int i = 0; i < lantonStand.Length; i++)
            {
                lantonStand[i] = GameObject.Find($"Wood {i + 1}");
            }

            lantonStandKey[0] = lantonStand[lantonLinkGimmick.caveTime[0] - 1];
            lantonStandKey[1] = lantonStand[lantonLinkGimmick.caveTime[1] - 1];
            lantonStandKey[2] = lantonStand[lantonLinkGimmick.caveTime[2] - 1];
        }

        private void Update()
        {
            
        }

        public void LantonPositioning()
        {
            
        }

        public void FstPostionController()
        {
           /* if (lantonStandNameKey.name == null)
            {
                Debug.Log($"{lantonStandNameKey.name}");
                return;
            }*/
                

            if (lantonStandKey[0].gameObject.name != lantonStandNameKey.name)
            {
                isFstPosition = false;
                Debug.Log($"Fst lanton flase");
            }

            if (lantonStandKey[0].gameObject.name == lantonStandNameKey.name)
            {
                isFstPosition = true;
                Debug.Log($"Fst lanton true");
            }
                
        }

        public void SecPostionController()
        {
           /* if (lantonStandNameKey.name == null)
            {
                Debug.Log($"{lantonStandNameKey.name}");
                return;
            }*/


            if (lantonStandKey[1].gameObject.name != lantonStandNameKey.name)
            {
                isSecPosition = false;
                Debug.Log($"Sec lanton flase");
            }
                

            if (lantonStandKey[1].gameObject.name == lantonStandNameKey.name)
            {
                Debug.Log($"Sec lanton true");
                isSecPosition = true;
            }
                
        }

        public void TrdPostionController()
        {
            /*if (lantonStandNameKey.name == null)
            {
                Debug.Log($"{lantonStandNameKey.name}");
                return;
            }*/


            if (lantonStandKey[0].gameObject.name != lantonStandNameKey.name)
            {
                Debug.Log($"Trd lanton false");
                isTrdPosition = false;
            }
                

            if (lantonStandKey[0].gameObject.name == lantonStandNameKey.name)
            {
                Debug.Log($"Trd lanton true");
                isTrdPosition = true;
            }
                
        }

        /* public void LantonPositioning()
         {
             for(int i = 0; i < lantonStand.Length; i++)
             {
                 if(lantonStand[i] == lantonLinkGimmick.caveTime[0])
                 {
                     lantonStand[i] = lantonLinkGimmick.caveTime[0];
                 }
             }

             for (int i = 0; i < lantonStand.Length; i++)
             {
                 if (lantonStand[i] == lantonLinkGimmick.caveTime[1])
                 {
                     lantonStand[i] = lantonLinkGimmick.caveTime[1];
                 }
             }

             for (int i = 0; i < lantonStand.Length; i++)
             {
                 if (lantonStand[i] == lantonLinkGimmick.caveTime[2])
                 {
                     lantonStand[i] = lantonLinkGimmick.caveTime[2];
                 }
             }
         }*/
    }
}
