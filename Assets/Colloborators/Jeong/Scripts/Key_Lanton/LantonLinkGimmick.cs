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

        bool isLantonClear;

        private void Start()
        {
            LantonGimmick();
        }

        /*private void LantonClaer()
        {
            if (!isLantonClear)
            GameManager.Data.isCaveLantonClear = true;
        }*/

        // �������� 3�� �̽�(�ߺ�����)
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
                        // Debug.Log($"i : {i}, j : {j} -> result: i == j (X)");
                    }
                    else if (i != j)
                    {
                        // Debug.Log($"i : {i}, j : {j} -> result: i != j (O)");
                        for (int k = 1; k < times.Length; k++)
                        {
                            k = Random.Range(1, times.Length + 1);
                            if (j == k)
                            {
                                // Debug.Log($"j : {j}, k : {k} -> result: j == k (X)");
                                //return;
                            }

                            else if (j != k)
                            {
                                // Debug.Log($"j : {j}, k : {k} -> result: j != k (O)");
                                if (i == k)
                                {
                                    // Debug.Log($"i : {i}, k : {k} -> result: i == k (X)");
                                }

                                else if (i != k)
                                {
                                    //Debug.Log($"i : {i}, k : {k} -> result: i != k (O)");
                                    //Debug.Log("****************************");
                                    Debug.Log($"i : {i}, j : {j}, k : {k}");
                                    //Debug.Log("****************************");
                                    GameManager.Data.caveTime[0] = i;
                                    GameManager.Data.caveTime[1] = j;
                                    GameManager.Data.caveTime[2] = k;
                                    return;
                                }
                            }
                        }
                    }

                }    
            }
            Debug.Log($"caveTime 0 : {GameManager.Data.caveTime[0]}");
            Debug.Log($"caveTime 1 : {GameManager.Data.caveTime[1]}");
            Debug.Log($"caveTime 2 : {GameManager.Data.caveTime[2]}");
        }
        #endregion
    }

}
