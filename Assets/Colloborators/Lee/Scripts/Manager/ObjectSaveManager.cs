using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using static UnityEditor.Rendering.FilterWindow;
using Unity.VisualScripting;
using System.Linq;
using static UnityEngine.GraphicsBuffer;

namespace Lee
{
    public class ObjectSaveManager : MonoBehaviour
    {
        public void SaveObj()
        {
            SaveData.current.objList = null;
            SaveData.current.invenList = null;

            InteratableObject[] targets = FindObjectsOfType<InteratableObject>();

            SaveData.current.invenList = new List<InventoryData>();
            SaveData.current.objList = new List<ObjectData>();

            foreach (InteratableObject target in targets)
            {
                if(target.IsInven == false)
                {
                    ObjectData objectData = new ObjectData();
                    objectData.name = target.name;
                    objectData.prefabPath = $"Puzzle/{target.name}";
                    objectData.position = target.position;
                    objectData.rotation = target.rotation;
                    objectData.isInven = target.IsInven;
                    SaveData.current.objList.Add(objectData);
                 }
                else
                {
                    InventoryData inventoryData = new InventoryData();
                    inventoryData.inObjName = target.name;
                    inventoryData.inObjprefabPath = $"Puzzle/{target.name}";
                    inventoryData.isInven = target.IsInven;
                    SaveData.current.invenList.Add(inventoryData);
                }
            }
        }

        public void LoadObj()
        {
            InteratableObject[] targets = FindObjectsOfType<InteratableObject>();

            foreach (InteratableObject target in targets)
            {
                if (target.IsInven == false) 
                {
                    GameManager.Pool.Release(target.gameObject);
                }
            }
            foreach (ObjectData obj in SaveData.current.objList)
            {
                InteratableObject targetPrefab = GameManager.Resource.Load<InteratableObject>(obj.prefabPath);
                GameManager.Pool.Get(targetPrefab, obj.position, obj.rotation);
            }
        }

        public void SceneInvenLoad()    
        {
            InteratableObject[] targets = FindObjectsOfType<InteratableObject>();
            foreach (InteratableObject target in targets)
            {
                for (int i = 0; i < SaveData.current.invenList.Count; i++)
                {
                    if (target.name == SaveData.current.invenList[i].inObjName)
                        return;
                    else
                    {
                        InteratableObject targetPrefab = GameManager.Resource.Load<InteratableObject>(SaveData.current.invenList[i].inObjprefabPath);
                        GameManager.Resource.Instantiate(targetPrefab);
                    }
                }
            }
        }

        public void SceneLoad()
        {
            LoadObj();
            SceneInvenLoad();
        }
    }
}

