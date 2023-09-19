using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bae
{
    public class RuneShader : MonoBehaviour
    {
        [SerializeField] Material material;
        public void RuneEffect()
        {
            StartCoroutine(RuneEffectRoutine());
        }
        IEnumerator RuneEffectRoutine()
        {
            float time = 0;
            while (time<3f)
            {
                material.SetFloat("_Dissove",Mathf.Lerp(1,0,time/3f));
                time += Time.deltaTime;
                yield return null;
            }
        }
    }
}

