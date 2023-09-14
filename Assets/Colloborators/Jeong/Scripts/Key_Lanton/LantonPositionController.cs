using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Jeong
{
    public class LantonPositionController : MonoBehaviour
    {
        [SerializeField] LantonLinkGimmick lantonLinkGimmick;
        LantonPositionNum lantonPositionNum;

        public GameObject[] lantonStand = new GameObject[12];
        public GameObject[] lantonStandKey = new GameObject[3];
        public int lantonStandPos1;
        public int lantonStandPos2;
        public int lantonStandPos3;

        bool isPosition = false;

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

        public void PostionController()
        {
            
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
