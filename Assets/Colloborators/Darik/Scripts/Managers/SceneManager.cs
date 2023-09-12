using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

namespace Darik
{
    public class SceneManager : MonoBehaviour
    {
        private BaseScene curScene;

        public BaseScene CurScene
        {
            get
            {
                if (curScene == null)
                    curScene = GameObject.FindObjectOfType<BaseScene>();

                return curScene;
            }
        }

        public void LoadScene(string sceneName)
        {
            GameManager.ObjM.SaveObj();
            Debug.Log("Save");
            StartCoroutine(LoadingCoroutine(sceneName));
        }

        IEnumerator LoadingCoroutine(string sceneName)
        {
            //GameManager.UI.FadeOut();
            yield return new WaitForSeconds(0.5f);
            Time.timeScale = 0f;

            AsyncOperation oper = UnitySceneManager.LoadSceneAsync(sceneName);
            while (!oper.isDone)
            {
                //loadingUI.SetProgress(Mathf.Lerp(0f, 0.5f, oper.progress));       플레이어의 로딩 진행바
                yield return null;
            }

            CurScene.LoadAsync();
            while (CurScene.progress < 1f)
            {
                //loadingUI.SetProgress(Mathf.Lerp(0.5f, 1.0f, CurScene.progress)); 플레이어의 로딩 진행바
                yield return null;
            }

            Time.timeScale = 1f;
            GameManager.ObjM.LoadObj();

            //GameManager.UI.FadeIn();
            yield return new WaitForSeconds(0.5f);
        }
    }
}
