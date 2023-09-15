
using UnityEngine;

namespace Jeong
{
    public class LantonPositionController : MonoBehaviour
    {
        [SerializeField] LantonLinkGimmick  lantonLinkGimmick;
        
        public LantonSocket[] lantonSocket = new LantonSocket[12];
        
        public GameObject[] lantonStand = new GameObject[12];
        public GameObject[] lantonStandKey = new GameObject[3];

        public bool isOnePosition = false;
        public bool isTwoPosition = false;
        public bool isThreePosition = false;

        private void Start()
        {
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
            for (int i = 0; i < lantonStand.Length; i++)
            {
                if (lantonSocket[i].isSocketed)
                {
                    for (int j = 0; j < lantonStand.Length; j++)
                    {
                        lantonStand[j] = GameObject.Find($"Wood {j + 1}");

                        if (lantonStandKey[0].name != lantonSocket[i].name)
                        {
                            Debug.Log($"Check : {lantonStandKey[0].name} 과 {lantonSocket[i].name} 의 값은 {lantonStandKey[0].name == lantonSocket[i].name}");
                            return;
                        }

                        if (lantonStandKey[0].name == lantonSocket[i].name)
                        {
                            isOnePosition = true;
                            Debug.Log($"Check : {lantonStandKey[0].name} 과 {lantonSocket[i].name} 의 값은 {lantonStandKey[0].name == lantonSocket[i].name}");
                            return;
                        }
                    }
                    return;
                }
            }

        }

        public void Check2()
        {
            for (int i = 0; i < lantonStand.Length; i++)
            {
                if (lantonSocket[i].isSocketed)
                {
                    for (int j = 0; j < lantonStand.Length; j++)
                    {
                        lantonStand[j] = GameObject.Find($"Wood {j + 1}");

                        if (lantonStandKey[1].name != lantonSocket[i].name)
                        {
                            Debug.Log($"Check : {lantonStandKey[1].name} 과 {lantonSocket[i].name} 의 값은 {lantonStandKey[1].name == lantonSocket[i].name}");
                            return;
                        }

                        if (lantonStandKey[1].name == lantonSocket[i].name)
                        {
                            isTwoPosition = true;
                            Debug.Log($"Check : {lantonStandKey[1].name} 과 {lantonSocket[i].name} 의 값은 {lantonStandKey[1].name == lantonSocket[i].name}");
                            return;
                        }
                    }
                    return;
                }
            }
        }

        public void Check3()
        {
            for (int i = 0; i < lantonStand.Length; i++)
            {
                if (lantonSocket[i].isSocketed)
                {
                    for (int j = 0; j < lantonStand.Length; j++)
                    {
                        lantonStand[j] = GameObject.Find($"Wood {j + 1}");

                        if (lantonStandKey[2].name != lantonSocket[i].name)
                        {
                            Debug.Log($"Check : {lantonStandKey[2].name} 과 {lantonSocket[i].name} 의 값은 {lantonStandKey[2].name == lantonSocket[i].name}");
                            return;
                        }

                        if (lantonStandKey[2].name == lantonSocket[i].name)
                        {
                            isThreePosition = true;
                            Debug.Log($"Check : {lantonStandKey[2].name} 과 {lantonSocket[i].name} 의 값은 {lantonStandKey[2].name == lantonSocket[i].name}");
                            return;
                        }
                    }
                    return;
                }
            }
        }

        public void LantonClear()
        {
            if(isOnePosition &&  isTwoPosition && isThreePosition)
            {
                Debug.Log("클리어");
            }
        }

        public void LantonPositioning()
        {
            
        }

      /*  public void FstPostionController()
        {
           *//* if (lantonStandNameKey.name == null)
            {
                Debug.Log($"{lantonStandNameKey.name}");
                return;
            }*//*
                

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
           *//* if (lantonStandNameKey.name == null)
            {
                Debug.Log($"{lantonStandNameKey.name}");
                return;
            }*//*


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
            *//*if (lantonStandNameKey.name == null)
            {
                Debug.Log($"{lantonStandNameKey.name}");
                return;
            }*//*


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

        *//* public void LantonPositioning()
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
