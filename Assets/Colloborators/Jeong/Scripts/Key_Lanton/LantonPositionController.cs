using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jeong
{
    public class LantonPositionController : MonoBehaviour
    {

        
        public LantonSocket[] lantonSocket = new LantonSocket[12];
        
        public GameObject[] lantonStand = new GameObject[12];
        public GameObject[] lantonStandKey = new GameObject[3];

        public bool isOnePosition = false;
        public bool isTwoPosition = false;
        public bool isThreePosition = false;

        private void Start()
        {
           
            LantonStandNumbering();
        }

        public void LantonStandNumbering()
        {
            if (!GameManager.Data.isLantonNumberingSet) // �����͸Ŵ������� lantonGimmickNumbering�� �����;��Ѵ�.
                return;

            for (int i = 0; i < lantonStand.Length; i++)
            {
                lantonStand[i] = GameObject.Find($"Wood {i + 1}");
            }
            lantonStandKey[0] = lantonStand[GameManager.Data.caveTime[0] - 1];
            lantonStandKey[1] = lantonStand[GameManager.Data.caveTime[1] - 1];
            lantonStandKey[2] = lantonStand[GameManager.Data.caveTime[2] - 1];
                     
        }


        public void Check1()
        {
            if (!GameManager.Data.isLantonNumberingSet) // �����͸Ŵ������� lantonGimmickNumbering�� �����;��Ѵ�.
                return;

            for (int i = 0; i < lantonStand.Length; i++)
            {
                if (lantonSocket[i].isSocketed)
                {
                    for (int j = 0; j < lantonStand.Length; j++)
                    {
                       
                        lantonStand[j] = GameObject.Find($"Wood {j + 1}");

                       
                        if (lantonStandKey[0].name == lantonSocket[i].name)
                        {
                            isOnePosition = true;
                            Debug.Log($"Check : {lantonStandKey[0].name} �� {lantonSocket[i].name} �� ���� {lantonStandKey[0].name == lantonSocket[i].name}");
                            return;
                        }
                    }
                }
            }
        }
            

        public void Check2()
        {
            if (!GameManager.Data.isLantonNumberingSet) // �����͸Ŵ������� lantonGimmickNumbering�� �����;��Ѵ�.
                return;

            for (int i = 0; i < lantonStand.Length; i++)
            {
                if (lantonSocket[i].isSocketed)
                {
                    for (int j = 0; j < lantonStand.Length; j++)
                    {
                        lantonStand[j] = GameObject.Find($"Wood {j + 1}");


                        if (lantonStandKey[1].name == lantonSocket[i].name)
                        {
                            isTwoPosition = true;
                            Debug.Log($"Check : {lantonStandKey[1].name} �� {lantonSocket[i].name} �� ���� {lantonStandKey[1].name == lantonSocket[i].name}");
                            return;
                        }
                    }
                }
            }

        }

        public void Check3()
        {
            if (!GameManager.Data.isLantonNumberingSet) // �����͸Ŵ������� lantonGimmickNumbering�� �����;��Ѵ�.
                return;

            for (int i = 0; i < lantonStand.Length; i++)
            {
                if (lantonSocket[i].isSocketed)
                {
                    for (int j = 0; j < lantonStand.Length; j++)
                    {
                        lantonStand[j] = GameObject.Find($"Wood {j + 1}");

                        if (lantonStandKey[2].name == lantonSocket[i].name)
                        {
                            isThreePosition = true;
                            Debug.Log($"Check : {lantonStandKey[2].name} �� {lantonSocket[i].name} �� ���� {lantonStandKey[2].name == lantonSocket[i].name}");
                            return;
                        }
                    }
                }
            }
        }

        public void LantonClear()
        {
            if (isOnePosition && isTwoPosition && isThreePosition)
            {
                GameManager.Data.isCaveLantonClear = true;
                Debug.Log("���ϱ�� Ŭ����");
            }
            else
                Debug.Log("���ϱ�� ������");
        }
    }
}
