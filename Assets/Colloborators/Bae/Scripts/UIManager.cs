using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Darik;
using Unity.VisualScripting;
using TMPro;

namespace Bae
{
    public class UIManager : MonoBehaviour
    {
        Canvas fadeCanvas;
        Canvas talkCanvas;
        TMP_Text TalkText;
        public FadeInOut fadeScene;

        private void OnEnable()
        {
            fadeCanvas = GameManager.Resource.Instantiate<Canvas>("UI/FadeCanvas", true);
            fadeScene = fadeCanvas.GetComponent<FadeInOut>();
        }

        public void FadeIn()
        {
            fadeScene.FadeIn();
        }

        public void FadeOut()
        {
            fadeScene.FadeOut();
        }
        /*
        //Test Sceneº¯°æ¿ë
        public void GoToScene(string sceneName)
        {
            StartCoroutine(GoTOSceneRoutine(sceneName));
        }

        IEnumerator GoTOSceneRoutine(string sceneName)
        {
            FadeOut();
            yield return new WaitForSeconds(fadeScene.fadeDuration);           
            GameManager.Scene.LoadScene(sceneName);
            FadeIn();
        }
        */
    }
}
