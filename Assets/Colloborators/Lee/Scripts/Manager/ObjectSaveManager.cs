using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using static UnityEditor.Rendering.FilterWindow;

    namespace Lee
{
    public class ObjectSaveManager : MonoBehaviour
    {
        //private string sceneName;
        //
        //
        //public string savePath; // 경로
        //
        //private void Awake()
        //{
        //    savePath = Application.persistentDataPath + "/save";    // 경로 지정
        //}
        //
        //public void SaveData1()
        //{
        //    string data = JsonUtility.ToJson(nowPlayer);
        //    File.WriteAllText(savePath + "EscapeSave", data);
        //}
        //
        //public void LoadData()
        //{
        //    string data = File.ReadAllText(savePath + nowSlot.ToString());
        //    nowPlayer = JsonUtility.FromJson<PlayerData_2>(data);
        //    UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        //}
        //
        //public void DataClear()
        //{
        //    nowSlot = -1;
        //    nowPlayer = new PlayerData_2();
        //}

        

        public void SaveObj()
        {
                SaveData.current.objList = new List<ObjectData>();
                InteratableObject[] targets = FindObjectsOfType<InteratableObject>();
                if(SaveData.current.objList == null)
                {
                foreach (InteratableObject target in targets)
                {
                    ObjectData objectData = new ObjectData();
                    objectData.prefabPath = target.resourcePath;
                    objectData.position = target.position;
                    objectData.rotation = target.rotation;
                    objectData.isIeventory = target.IsInven;
                    SaveData.current.objList.Add(objectData);
                }
            }

                foreach (InteratableObject target in targets)
                {
                    ObjectData objectData = new ObjectData();
                    objectData.position = target.position;
                    objectData.rotation = target.rotation;
                    objectData.isIeventory = target.IsInven;
                    SaveData.current.objList.Add(objectData);
                }
        }

        public void LoadObj() 
        {

            InteratableObject[] targets = FindObjectsOfType<InteratableObject>();

            if (SaveData.current.objList != null)
            {
                foreach (InteratableObject target in targets)
                {
                    Destroy(target.gameObject);
                }
                foreach (ObjectData obj in SaveData.current.objList)
                {
                    InteratableObject targetPrefab = GameManager.Resource.Load<InteratableObject>(obj.prefabPath);
                    GameManager.Resource.Instantiate(targetPrefab, obj.position, obj.rotation);                
                }
            }

            else
            {
                SaveData.current.objList = new List<ObjectData>();
                foreach (InteratableObject target in targets)
                {
                    ObjectData objectData = new ObjectData();
                    objectData.prefabPath = target.resourcePath;
                    objectData.position = target.position;
                    objectData.rotation = target.rotation;
                    objectData.isIeventory = target.IsInven;
                    SaveData.current.objList.Add(objectData);
                    Debug.Log("자동저장");
                }
            }
        }
    }
}

