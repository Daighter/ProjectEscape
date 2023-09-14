using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jeong
{
    public class LantonPositionController : MonoBehaviour
    {
        LantonLinkGimmick lantonLinkGimmick;
        LantonPositionNum lantonPositionNum;

        public GameObject[] lantonStand;


        private void Start()
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
