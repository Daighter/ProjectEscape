using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor.SceneManagement;

namespace Lee
{
    public class PlayerData_2
    {
       //// �̸�, ����, ����, �������� ����
       //public string name;
       //public Vector3 position;
       //public Quaternion rotation;
       //public string sceneName;
    }

    public class SaveManager_Json : MonoBehaviour
    {
       //public static SaveManager_Json instance; // �̱�������
       //private string sceneName;
       //
       //public PlayerData_2 nowPlayer = new PlayerData_2(); // �÷��̾� ������ ����
       //
       //public string savePath; // ���
       //public int nowSlot; // ���� ���Թ�ȣ
       //
       //private void Awake()
       //{
       //    #region �̱���
       //    if (instance == null)
       //    {
       //        instance = this;
       //    }
       //    else if (instance != this)
       //    {
       //        Destroy(instance.gameObject);
       //    }
       //    DontDestroyOnLoad(this.gameObject);
       //    #endregion
       //    savePath = Application.persistentDataPath + "/save";    // ��� ����
       //    print(savePath);
       //}
       //
       //public void AutoSave()
       //{
       //}
       //
       //public void SaveData()
       //{
       //    string data = JsonUtility.ToJson(nowPlayer);
       //    File.WriteAllText(savePath + nowSlot.ToString(), data);
       //}
       //
       //public void LoadData()
       //{
       //     string data = File.ReadAllText(savePath + nowSlot.ToString());
       //     nowPlayer = JsonUtility.FromJson<PlayerData_2>(data);
       //     UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
       //}
       //
       //public void DataClear()
       //{
       //    nowSlot = -1;
       //    nowPlayer = new PlayerData_2();
       //}
    }
}


