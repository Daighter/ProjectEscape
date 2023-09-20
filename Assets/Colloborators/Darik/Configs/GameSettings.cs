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
            // ������ �����ϱ� �� �ʿ��� ������
            if (GameManager.Instance == null)
            {
                GameObject gameManager = new GameObject() { name = "GameManager" };
                gameManager.AddComponent<GameManager>();
            }
        }
    }
}
