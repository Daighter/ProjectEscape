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
        public void SaveObj()
        {
            InteratableObject[] targets = FindObjectsOfType<InteratableObject>();
            NomalObject[] nomals = FindObjectsOfType<NomalObject>();
            ColorChanger[] colors = FindObjectsOfType<ColorChanger>();
            

            if (targets.Any() != false)
            {
                SaveData.current.objList = new List<ObjectData>();
                SaveData.current.invenList = new List<InventoryData>();

                foreach (InteratableObject target in targets)
                {
                     ObjectData objectData = new ObjectData();
                     objectData.name = target.name;
                     objectData.prefabPath = $"Puzzle/{target.name}";
                     objectData.position = target.transform.position;
                     objectData.rotation = target.transform.rotation;
                     SaveData.current.objList.Add(objectData);
                   //if (target.IsInven == true)
                   //{
                   //    InventoryData inventoryData = new InventoryData();
                   //    inventoryData.inObjName = target.name;         
                   //    inventoryData.inObjprefabPath = $"Puzzle/{target.name}";
                   //    inventoryData.position = target.transform.position;
                   //    inventoryData.rotation = target.transform.rotation;
                   //    inventoryData.isInven = true;
                   //    inventoryData.itemScale = target.transform.lossyScale;
                   //    SaveData.current.invenList.Add(inventoryData);
                   //    target.transform.SetParent(transform, false);
                   //}
                }
            }

            if (nomals.Any() != false)
            {
                SaveData.current.nomalObjList = new List<NomalObjData>();
                foreach (NomalObject nomal in nomals)
                {
                    if (nomal.enabled == true)
                    {
                        NomalObjData nomalObjData = new NomalObjData();
                        nomalObjData.name = nomal.gameObject.name;
                        nomalObjData.enable = nomal.ObjActive;
                        nomalObjData.position = nomal.transform.position;
                        nomalObjData.rotation = nomal.transform.rotation;
                        SaveData.current.nomalObjList.Add(nomalObjData);
                    }
                }
            }

            if (colors.Any() != false)
            {
                SaveData.current.colorList = new List<ColorData>();
                foreach (ColorChanger target in colors)
                {
                    ColorData colorData = new ColorData();
                    colorData.name = target.gameObject.name;
                    colorData.colorIndex = target.CurIndex;
                    SaveData.current.colorList.Add(colorData);
                }
            }
        }

        public void LoadObj()
        {
            InteratableObject[] targets = FindObjectsOfType<InteratableObject>();
            NomalObject[] nomals = FindObjectsOfType<NomalObject>();
            ColorChanger[] colors = FindObjectsOfType<ColorChanger>();
            //PositionTracking socket = FindObjectOfType<PositionTracking>();

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
                   //foreach (InventoryData inven in SaveData.current.invenList)
                   //{
                   //    if (target.name == inven.inObjName)
                   //    {
                   //        target.gameObject.name = inven.inObjName;
                   //        target.IsInven = inven.isInven;
                   //        target.transform.position = socket.transform.position;
                   //        target.transform.localScale = inven.itemScale;
                   //        target.transform.SetParent(socket.transform, false);
                   //    }
                   //}
                }
            }

            if (nomals.Any() != false)
            {
                foreach (NomalObject nomal in nomals)
                {
                    foreach (NomalObjData obj in SaveData.current.nomalObjList)
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
                    foreach (ColorData obj in SaveData.current.colorList)
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

