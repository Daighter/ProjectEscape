using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TrueEnd : MonoBehaviour
{
    [SerializeField] RectTransform badEndBlack;
    [SerializeField] string sceneName = null;

    [SerializeField] TMP_Text trueEnd;
    [SerializeField] Color textColor;

    public void TrueEnding(float trueDuration)
    {
        badEndBlack.gameObject.SetActive(true);
        badEndBlack.localPosition = new Vector3(0f, 0f, 11f);
        StartCoroutine(TrueEndRoutine(trueDuration));
    }

    IEnumerator TrueEndRoutine(float trueDuration)
    {
        float time = 0;
        while (time < trueDuration)
        {
            Color newColor = textColor;
            newColor.a = Mathf.Lerp(0, 1, time / trueDuration);
            trueEnd.color = newColor;
            time += Time.deltaTime;

            yield return null;
        }
        Color newColor2 = textColor;
        newColor2.a = 1;
        trueEnd.color = newColor2;

        yield return new WaitForSeconds(trueDuration);
        Quit();
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
Application.OpenURL("http://google.com");
#else
Application.Quti();
#endif
    }
}
