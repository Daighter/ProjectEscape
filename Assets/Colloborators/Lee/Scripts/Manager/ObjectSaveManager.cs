using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using static UnityEditor.Rendering.FilterWindow;
using Unity.VisualScripting;
using System.Linq;
using static UnityEngine.GraphicsBuffer;
using Darik;
using UnityEditor.SearchService;

namespace Lee
{
    public class ObjectSaveManager : MonoBehaviour
    {
        private string scene;
        public void SaveObj()
        {
            scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            SaveData.current.objList = null;
            SaveData.current.invenList = null;

            InteratableObject[] targets = FindObjectsOfType<InteratableObject>();
            NomalObject[] nomals = FindObjectsOfType<NomalObject>();
            ColorChanger[] colors = FindObjectsOfType<ColorChanger>();

            SaveData.current.invenList = new List<InventoryData>();
            SaveData.current.objList = new List<ObjectData>();

            foreach (InteratableObject target in targets)
            {
                if(target.IsInven == false)
                {
                    ObjectData objectData = new ObjectData();
                    objectData.name = target.name;
                    objectData.prefabPath = $"Puzzle/{target.name}";
                    objectData.position = target.transform.position;
                    objectData.rotation = target.transform.rotation;
                    objectData.isInven = target.IsInven;
                    SaveData.current.objList.Add(objectData);
                }

                if (target.IsInven == true)
                {
                    InventoryData inventoryData = new InventoryData();
                    inventoryData.inObjName = target.name;
                    inventoryData.inObjprefabPath = $"Puzzle/{target.name}";
                    inventoryData.position = target.transform.position;
                    inventoryData.rotation = target.transform.rotation;
                    inventoryData.isInven = target.IsInven;
                    inventoryData.itemScale = target.Scale;
                    SaveData.current.invenList.Add(inventoryData);
                }
            }

            foreach(NomalObject nomal in nomals)
            {
                if(nomal.enabled == true)
                {
                    ObjectData objectData = new ObjectData();
                    objectData.enable = nomal.ObjActive;
                    objectData.position = nomal.Position;
                    objectData.rotation = nomal.Rotation;
                    SaveData.current.objList.Add(objectData);
                }
            }

            foreach (ColorChanger target in colors)
            {
                ObjectData objectData = new ObjectData();
                objectData.colorIndex = target.CurIndex;
                SaveData.current.objList.Add(objectData);
            }
        }

        public void LoadObj()
        {
            scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            InteratableObject[] targets = FindObjectsOfType<InteratableObject>();
            NomalObject[] nomals = FindObjectsOfType<NomalObject>();
            ColorChanger[] colors = FindObjectsOfType<ColorChanger>();

            if (targets.Any() != false )
            {
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
                    targetPrefab.IsInven = obj.isInven;
                }

                foreach (InventoryData inven in SaveData.current.invenList)
                {
                    InteratableObject targetPrefab = GameManager.Resource.Load<InteratableObject>(inven.inObjprefabPath);
                    GameManager.Resource.Instantiate(targetPrefab, inven.position, inven.rotation);
                    targetPrefab.name = inven.inObjName;
                    targetPrefab.IsInven = inven.isInven;
                    targetPrefab.Scale = inven.itemScale;
                }
            }
            if(nomals.Any() != false )
            {
                for (int i = 0; i < nomals.Length; i++)
                {
                    foreach (ObjectData obj in SaveData.current.objList)
                    {
                        if (obj.name == nomals[i].name)
                        {
                            nomals[i].ObjActive = obj.enable;
                            nomals[i].Position = obj.position;
                            nomals[i].Rotation = obj.rotation;
                        }
                    }
                }

            }
            if(colors.Any() != false)
            {
                for (int i = 0; i < colors.Length; i++)
                {
                    foreach (ObjectData obj in SaveData.current.objList)
                    {
                        if (obj.name == colors[i].name)
                        {
                            colors[i].CurIndex = obj.colorIndex;
                        }
                    }
                }
            }
        }

        public void SceneLoad()
        {
            LoadObj();
        }
    }
}

