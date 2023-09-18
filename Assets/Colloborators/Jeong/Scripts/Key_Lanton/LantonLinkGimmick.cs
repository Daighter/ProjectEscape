using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Jeong
{
    public class LantonLinkGimmick : MonoBehaviour
    {
        private int[] times = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

        private void Start()
        {
            LantonGimmick();
        }

        // 랜덤숫자 3개 뽑시(중복없음)
        #region 
        
        public void LantonGimmick()
        {
            if (GameManager.Data.isLantonNumberingSet == true)
            {
                return;
            }

            for (int i = 1; i < times.Length; i++)
            {
                i = Random.Range(1, times.Length + 1);

                for (int j = 1; j < times.Length; j++)
                {
                    j = Random.Range(1, times.Length + 1);

                    if (i != j)
                    {   
                        for (int k = 1; k < times.Length; k++)
                        {
                            k = Random.Range(1, times.Length + 1);
                            if (j != k && k != j)
                            {
                                Debug.Log($"i : {i}, j : {j}, k : {k}");
                                GameManager.Data.caveTime[0] = i;
                                GameManager.Data.caveTime[1] = j;
                                GameManager.Data.caveTime[2] = k;
                                GameManager.Data.isLantonNumberingSet = true; // 데이터매니저로 lantonGimmickNumbering을 보내야한다.
                                return;
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
