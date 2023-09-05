using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Lee
{
    public class PlayerData
    {
        // 이름, 레벨, 코인, 착용중인 무기
        public string name;
        public int level = 1;
        public int coin = 100;
        public int item = -1;
    }

    public class SaveManager : MonoBehaviour
    {
        public static SaveManager instance; // 싱글톤패턴
        private string sceneName;

        public PlayerData nowPlayer = new PlayerData(); // 플레이어 데이터 생성

        public string path; // 경로
        public int nowSlot; // 현재 슬롯번호

        private void Awake()
        {
            #region 싱글톤
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(instance.gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
            #endregion
            path = Application.persistentDataPath + "/save";    // 경로 지정
            print(path);
        }

        public void SaveData()
        {
            sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            string data = JsonUtility.ToJson(nowPlayer);
            File.WriteAllText(path + nowSlot.ToString(), data);
        }

        public void LoadData()
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != sceneName)
            {
                string data = File.ReadAllText(path + nowSlot.ToString());
                nowPlayer = JsonUtility.FromJson<PlayerData>(data);
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            }
            else
            {
                string data = File.ReadAllText(path + nowSlot.ToString());
                nowPlayer = JsonUtility.FromJson<PlayerData>(data);
            }
        }

        public void DataClear()
        {
            nowSlot = -1;
            nowPlayer = new PlayerData();
        }
    }
}


