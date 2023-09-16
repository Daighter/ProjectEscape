using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class PendantGaze : MonoBehaviour
    {
        [SerializeField] private bool debug;
        [SerializeField] private GameObject player;
        [SerializeField] private bool isMainRoom;
        [SerializeField] private string MainRoomSceneName;
        [SerializeField] private float maxGazeSeconds = 5f;

        private new Renderer renderer;
        private bool updateTimer = false;
        private float curGazedTime = 0f;

        private void Awake()
        {
            renderer = GetComponent<Renderer>();
        }

        private void Start()
        {
            GameManager.Data.SetPendantColor(GameManager.Scene.CurScene.SceneNum, renderer);
        }

        private void Update()
        {
            if (updateTimer)
                UpdateTimer();
        }

        private void UpdateTimer()
        {
            curGazedTime += Time.deltaTime;
            if (curGazedTime >= maxGazeSeconds)
            {
                curGazedTime = 0f;
                if (MainRoomSceneName != null || MainRoomSceneName != "")
                {
                    player.GetComponentInChildren<Bae.FadeInOut>().FadeOut();
                    GameManager.Scene.LoadScene(MainRoomSceneName);
                }
            }
        }

        public void UpdateTimerState(bool state)
        {
            if (!isMainRoom)
            {
                if (debug)
                    Debug.Log(state);
                updateTimer = state;

                if (state)
                {
                    renderer.material = GameManager.Resource.Load<Material>("Prefabs/Puzzles/Pendants/JewalColors/None");
                    renderer.material.color = Color.white;
                }
                else
                {
                    curGazedTime = 0f;
                    GameManager.Data.SetPendantColor(GameManager.Scene.CurScene.SceneNum, renderer);
                }
            }
        }
    }
}
