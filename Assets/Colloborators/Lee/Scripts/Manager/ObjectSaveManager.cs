using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using static UnityEditor.Rendering.FilterWindow;
using Unity.VisualScripting;
using System.Linq;

namespace Lee
{
    public class ObjectSaveManager : MonoBehaviour
    {
        public void SaveObj()
        {
            InteratableObject[] targets = FindObjectsOfType<InteratableObject>();
            SaveData.current.invenList.Clear();
            SaveData.current.objList.Clear();

            SaveData.current.invenList = new List<InventoryData>();
            SaveData.current.objList = new List<ObjectData>();

            foreach (InteratableObject target in targets)
            {
                if(target.isInven == true)
                {

                    InventoryData inventoryData = new InventoryData ();
                    inventoryData.inObjName = target.name;
                    inventoryData.inObjprefabPath = $"Puzzle/{target.name}";
                    SaveData.current.invenList.Add (inventoryData);
                }
                else
                {
                    ObjectData objectData = new ObjectData();
                    objectData.name = target.name;
                    objectData.prefabPath = $"Puzzle/{target.name}";
                    objectData.position = target.position;
                    objectData.rotation = target.rotation;
                    SaveData.current.objList.Add(objectData);
                }
            }
        }

        public void LoadObj() 
        {
            SaveObj();          // Load먼저 눌렀을때 오류 방지
            InteratableObject[] targets = FindObjectsOfType<InteratableObject>();
            foreach (InteratableObject target in targets)
            {
                GameManager.Pool.Release(target.gameObject);
            }
            foreach (ObjectData obj in SaveData.current.objList)
            {
                InteratableObject targetPrefab = GameManager.Resource.Load<InteratableObject>(obj.prefabPath);
                GameManager.Pool.Get(targetPrefab, obj.position, obj.rotation);
            }
        }
    }
}

