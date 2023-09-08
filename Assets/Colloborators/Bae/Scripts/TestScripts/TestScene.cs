using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Bae
{
    public class TestScene : MonoBehaviour
    {
        public UIManager uiManager;
        public void GoToScene(string sceneName)
        {
            StartCoroutine(GoTOSceneRoutine(sceneName));
        }

        IEnumerator GoTOSceneRoutine(string sceneName)
        {
            uiManager.FadeOut();
            yield return new WaitForSeconds(uiManager.fadeScene.fadeDuration);
            SceneManager.LoadScene(sceneName);
        }
    }
}

