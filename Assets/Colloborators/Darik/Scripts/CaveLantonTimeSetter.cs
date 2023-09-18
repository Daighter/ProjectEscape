using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darrk
{
    public class CaveLantonTimeSetter : MonoBehaviour
    {
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
                Debug.Log(GameManager.Data.caveTime[i]);

                float angle;
                if (GameManager.Data.caveTime[i] != 12)
                    angle = GameManager.Data.caveTime[i] * 30f;
                else
                    angle = 0f;

                clockhands[i].localRotation = Quaternion.Euler(-90f, 0f, -angle); ;
                Debug.Log(angle);
            }
        }
    }
}
