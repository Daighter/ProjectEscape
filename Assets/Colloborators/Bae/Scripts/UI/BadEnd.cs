using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Bae
{
    public class BadEnd : MonoBehaviour
    {
        [SerializeField] TMP_Text badEnd;
        [SerializeField] Image image;
        [SerializeField] Color backColor;
        [SerializeField] Color textColor;


        public void BadEndOn(float badDuration)
        {
            gameObject.SetActive(true);
            StartCoroutine(BadEndRoutine(badDuration));
        }
        IEnumerator BadEndRoutine(float badDuration)
        {
            float time = 0;
            while(time<badDuration)
            {
                Color newColor = backColor;
                newColor.a=Mathf.Lerp(0, 1, time/badDuration);
                image.color= newColor;
                time += Time.deltaTime;

                yield return null;
            }
            Color backNewColor = backColor;
            backNewColor.a = 1;
            image.color = backNewColor;
            time = 0;
            while(time<(badDuration/2))
            {
                Color newColor = textColor;
                newColor.a= Mathf.Lerp(0, 1, time / (badDuration/2));
                badEnd.color= newColor;
                time += Time.deltaTime;

                yield return null;
            }
            Color textNewColor = textColor;
            textNewColor.a = 1;
            badEnd.color = textNewColor;
        }
    }
    
}

