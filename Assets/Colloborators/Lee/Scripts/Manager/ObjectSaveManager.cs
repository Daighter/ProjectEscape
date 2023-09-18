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
using UnityEngine.SocialPlatforms;

namespace Lee
{
    public class ObjectSaveManager : MonoBehaviour
    {
        private string scene;
        public void SaveObj()
        {
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
                    objectData.isInven = false;
                    SaveData.current.objList.Add(objectData);
                }

                if (target.IsInven == true)
                {
                    InventoryData inventoryData = new InventoryData();
                    inventoryData.inObjName = target.name;
                    inventoryData.inObjprefabPath = $"Puzzle/{target.name}";
                    inventoryData.position = target.transform.position;
                    inventoryData.rotation = target.transform.rotation;
                    inventoryData.isInven = true;
                    inventoryData.itemScale = target.transform.lossyScale;
                    SaveData.current.invenList.Add(inventoryData);
                }
            }

            foreach(NomalObject nomal in nomals)
            {
                if(nomal.enabled == true)
                {
                    ObjectData objectData = new ObjectData();
                    objectData.name = nomal.gameObject.name;
                    objectData.enable = nomal.ObjActive;
                    objectData.position = nomal.transform.position;
                    objectData.rotation = nomal.transform.rotation;
                    SaveData.current.objList.Add(objectData);
                }
            }

            foreach (ColorChanger target in colors)
            {
                ObjectData objectData = new ObjectData();
                objectData.name = target.gameObject.name;
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

            if (targets.Any() != false)
            {
                foreach (InteratableObject target in targets)
                {
                    foreach (ObjectData obj in SaveData.current.objList)
                    {
                        if (obj.name == target.name)
                        {
                            target.gameObject.name = obj.name;
                            target.IsInven = obj.isInven;
                            target.transform.position = obj.position;
                            target.transform.rotation = obj.rotation;
                        }
                    }
                    foreach (InventoryData inven in SaveData.current.invenList)
                    {
                        if (target.name == inven.inObjName)
                        {
                            target.gameObject.name = inven.inObjName;
                            target.IsInven = inven.isInven;
                            target.transform.position = inven.position;
                            target.transform.rotation = inven.rotation;
                            target.transform.localScale = inven.itemScale;
                        }
                        InteratableObject targetPrefab = GameManager.Resource.Load<InteratableObject>(inven.inObjprefabPath);
                        GameManager.Pool.Get(targetPrefab, inven.position, inven.rotation);
                        targetPrefab.transform.localScale = inven.itemScale;
                        GameManager.Pool.Release(targetPrefab);
                    }
                }
            }
            else
            {
                foreach (InventoryData inven in SaveData.current.invenList)
                {
                    InteratableObject targetPrefab = GameManager.Resource.Load<InteratableObject>(inven.inObjprefabPath);
                    GameManager.Resource.Instantiate(targetPrefab, inven.position, inven.rotation);
                    targetPrefab.transform.localScale = inven.itemScale;
                }
            }

            if (nomals.Any() != false)
            {
                foreach (NomalObject nomal in nomals)
                {
                    foreach (ObjectData obj in SaveData.current.objList)
                    {
                        if (obj.name == nomal.name)
                        {
                            nomal.ObjActive = obj.enable;
                            nomal.transform.position = obj.position;
                            nomal.transform.rotation = obj.rotation;
                        }
                    }
                }
            }

            if (colors.Any() != false)
            {
                foreach (ColorChanger color in colors)
                {
                    foreach (ObjectData obj in SaveData.current.objList)
                    {
                        if (obj.name == color.name)
                        {
                            color.CurIndex = obj.colorIndex;
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

