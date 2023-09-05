using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Lee
{
    public class PlayerData
    {
        // �̸�, ����, ����, �������� ����
        public string name;
        public int level = 1;
        public int coin = 100;
        public int item = -1;
    }

    public class SaveManager : MonoBehaviour
    {
        public static SaveManager instance; // �̱�������
        private string sceneName;

        public PlayerData nowPlayer = new PlayerData(); // �÷��̾� ������ ����

        public string path; // ���
        public int nowSlot; // ���� ���Թ�ȣ

        private void Awake()
        {
            #region �̱���
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
            path = Application.persistentDataPath + "/save";    // ��� ����
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


