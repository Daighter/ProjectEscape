using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Bae
{
    public class FadeInOut : MonoBehaviour
    {
        public float fadeDuration = 2;
        public Color fadeColor;
        public Image image;

        private void OnEnable()
        {
            FadeIn();
        }
        public void FadeIn()
        {
            Fade(1, 0);
        }

        public void FadeOut()
        {
            
            Fade(0, 1);
            
        }

        public void Fade(float alphIn,float alphOut)
        {
            StartCoroutine(FadeRoutine(alphIn,alphOut));
        }

        public IEnumerator FadeRoutine(float alphIn, float alphOut)
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
