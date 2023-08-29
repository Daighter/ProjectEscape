using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class GameSettings : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Init()
        {
            // 게임을 시작하기 전 필요한 설정들
            if (GameManager.Instance == null)
            {
                GameObject gameManager = new GameObject() { name = "GameManager" };
                gameManager.AddComponent<GameManager>();
            }
        }
    }
}
