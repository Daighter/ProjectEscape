using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class PendantGaze : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private bool isMainRoom;
        [SerializeField] private string MainRoomSceneName;
        [SerializeField] private float maxGazeSeconds = 5f;

        private bool updateTimer = false;
        private float curGazedTime = 0f;

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
                Debug.Log(state);
                updateTimer = state;
            }
        }
    }
}
