using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darrk
{
    public class CaveLantonTimeSetter : MonoBehaviour
    {
        [SerializeField] private bool debug;
        [SerializeField] private Transform[] clockhands;

        private void Start()
        {
            StartCoroutine(SetLantonTimeCoroutine());
        }

        IEnumerator SetLantonTimeCoroutine()
        {
            yield return new WaitForSeconds(1.1f);
            SetLantonTime();
        }

        public void SetLantonTime()
        {
            for (int i = 0; i < GameManager.Data.caveTime.Length; i++)
            {
                float angle;
                if (GameManager.Data.caveTime[i] != 12)
                    angle = GameManager.Data.caveTime[i] * 30f;
                else
                    angle = 0f;

                clockhands[i].localRotation = Quaternion.Euler(-90f, 0f, -angle);
            }

            if (debug)
                Debug.Log($"{GameManager.Data.caveTime[0]}½Ã {GameManager.Data.caveTime[1] * 5}ºÐ {GameManager.Data.caveTime[2]* 5}ÃÊ");
        }
    }
}
