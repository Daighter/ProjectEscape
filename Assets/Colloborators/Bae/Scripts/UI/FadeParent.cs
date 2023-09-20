using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Bae
{
    public abstract class FadeParent : MonoBehaviour
    {

        protected IEnumerator FadeParentRoutine(float alphIn, float alphOut,Color color, float fadeDuration,bool textColor=false)
        {
            float timer = 0;
            Time.timeScale = 0f;
            while (timer < fadeDuration)
            {
                Color newColor = color;
                newColor.a = Mathf.Lerp(alphIn, alphOut, timer / fadeDuration);
                Func(newColor);
                timer += Time.unscaledDeltaTime;
                yield return null;
            }

            Color newColor2 = color;
            newColor2.a = alphOut;
            Func(newColor2);
            Time.timeScale = 1f;
        }
       public abstract void Func(Color color);
    }
}

