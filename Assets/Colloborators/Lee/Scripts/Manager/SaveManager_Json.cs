using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor.SceneManagement;

namespace Lee
{
    public class PlayerData_2
    {
       //// 이름, 레벨, 코인, 착용중인 무기
       //public string name;
       //public Vector3 position;
       //public Quaternion rotation;
       //public string sceneName;
    }

    public class SaveManager_Json : MonoBehaviour
    {
       //public static SaveManager_Json instance; // 싱글톤패턴
       //private string sceneName;
       //
       //public PlayerData_2 nowPlayer = new PlayerData_2(); // 플레이어 데이터 생성
       //
       //public string savePath; // 경로
       //public int nowSlot; // 현재 슬롯번호
       //
       //private void Awake()
       //{
       //    #region 싱글톤
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
       //    savePath = Application.persistentDataPath + "/save";    // 경로 지정
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


