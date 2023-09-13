using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Jeong
{
    public class LantonLinkGimmick : MonoBehaviour
    {
        private int[] times = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

        public int[] caveTime = new int[3];
        public bool isCaveClear = false;
        
        // 랜덤숫자 3개 뽑시(중복없음)
        #region 
        public void LantonGimmick()
        {
            for (int i = 1; i < times.Length; i++)
            {
                i = Random.Range(1, times.Length + 1);
                
                for (int j = 1; j < times.Length; j++)
                {
                    j = Random.Range(1, times.Length + 1);
                    
                    if(i == j)
                    {
                        Debug.Log($"i : {i}, j : {j} -> result: i == j");
                    }
                    else if (i != j)
                    {
                        Debug.Log($"i : {i}, j : {j} -> result: i != j");
                        for (int k = 1; k < times.Length; k++)
                        {
                            k = Random.Range(1, times.Length + 1);
                            if (j == k)
                            {
                                Debug.Log($"j : {j}, k : {k} -> result: j == k");
                                //return;
                            }

                            else if (j != k)
                            {
                                Debug.Log($"j : {j}, k : {k} -> result: j != k");
                                if (i == k)
                                {
                                    Debug.Log($"i : {i}, k : {k} -> result: i == k");
                                }

                                else if (i != k)
                                {
                                    Debug.Log($"i : {i}, k : {k} -> result: i != k");
                                    Debug.Log("****************************");
                                    Debug.Log($"i : {i}, j : {j}, k : {k}");
                                    Debug.Log("****************************");
                                    caveTime[0] = i;
                                    caveTime[1] = j;
                                    caveTime[2] = k;
                                    return;
                                }
                            }
                        }
                    }

                }    
            }
            Debug.Log($"caveTime 0 : {caveTime[0]}");
            Debug.Log($"caveTime 1 : {caveTime[1]}");
            Debug.Log($"caveTime 2 : {caveTime[2]}");
        }
        #endregion
    }

}
