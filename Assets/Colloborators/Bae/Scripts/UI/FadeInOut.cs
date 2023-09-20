using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Bae
{
    public class FadeInOut : MonoBehaviour
    {
        public Image image;
        public Color fadeColor;

        private void OnEnable()
        {
            FadeIn();
        }
        public void FadeIn()
        {
            Fade(1,0);
        }

        public void FadeOut()
        {
            
            Fade(0, 1);
            
        }

        public void Fade(float alphIn,float alphOut,float fadeDuration=2)
        {
            StartCoroutine(FadeRoutine(alphIn,alphOut,fadeDuration));
        }

        public IEnumerator FadeRoutine(float alphIn, float alphOut,float fadeDuration)
        {
            float timer = 0;
            Time.timeScale = 0f;
            while (timer < fadeDuration)
            {
                Color newColor = fadeColor;
                newColor.a = Mathf.Lerp(alphIn, alphOut, timer/fadeDuration);

                image.color = newColor;

                timer += Time.unscaledDeltaTime;
                yield return null;
            }
            
            Color newColor2 = fadeColor;
            newColor2.a = alphOut;
            image.color = newColor2;
            Time.timeScale = 1f;
        }
    }
}
