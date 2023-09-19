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
            yield return new WaitForSeconds(0.5f);
            Time.timeScale = 0f;

            AsyncOperation oper = UnitySceneManager.LoadSceneAsync(sceneName);
            while (!oper.isDone)
            {
                yield return null;
            }

            CurScene.LoadAsync();
            while (CurScene.progress < 1f)
            {
                yield return null;
            }

            Time.timeScale = 1f;
            GameManager.ObjM.SceneLoad();
            Debug.Log("Load");
            GameManager.ObjM.SaveObj();
            Debug.Log("Save");

            yield return new WaitForSeconds(0.5f);
        }
    }
}
