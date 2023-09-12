using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Rendering.FilterWindow;

    namespace Lee
{
    public class ObjectSaveManager : MonoBehaviour
    {
        public void SaveObj()
        {
            SaveData.current.objList = new List<ObjectData>();
            InteratableObject[] targets = FindObjectsOfType<InteratableObject>();

               foreach (InteratableObject target in targets)
               {
                  ObjectData objectData = new ObjectData();
                  objectData.name = target.name;
                  objectData.prefabPath = target.resourcePath;
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
                    GameManager.Resource.Instantiate(targetPrefab, obj.position, obj.rotation);                }
            }

            else
            {
                SaveData.current.objList = new List<ObjectData>();
                foreach (InteratableObject target in targets)
                {
                    ObjectData objectData = new ObjectData();
                    objectData.name = target.name;
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

