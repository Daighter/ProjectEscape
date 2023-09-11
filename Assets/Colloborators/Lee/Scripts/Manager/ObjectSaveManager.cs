using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Rendering.FilterWindow;

    namespace Lee
{
    public class ObjectSaveManager : MonoBehaviour
    {
        ObjectData objData;
        public void SaveObj()
        {
            
            InteratableObject[] targets = FindObjectsOfType<InteratableObject>();
           if(targets == null)
           {
               foreach (InteratableObject target in targets)
               {
                  //target.name = target.name;
                  //target.prefabPath = target.resourcePath;
                  //target.position = target.position;
                  //target.rotation = target.rotation;
                  //target.isIeventory = target.IsSokect;
                  //SaveData.current.objList.Add(objData);
                }
           }
                
           
           for (int i = 0; i < SaveData.current.objList.Count; i++)
           {
               for (int j = 0; j < targets.Length; j++)
               {
                   if(SaveData.current.objList[i].name == targets[j].name)
                   {
                         SaveData.current.objList[i].position = targets[j].transform.position;
                         SaveData.current.objList[i].rotation = targets[j].transform.rotation;
                         SaveData.current.objList[i].isIeventory = targets[j].IsSokect;
                   }
               }
           }
        }


        public void LoadObj() 
        {
            InteratableObject[] targets = FindObjectsOfType<InteratableObject>();
            Debug.Log("dsdafasdf");

              foreach (InteratableObject target in targets)
              {
                  Destroy(target.gameObject);
              }
            
             
            for (int i = 0; i < SaveData.current.objList.Count; i++)                // 세이브데이터 List 와 배열을 비교하면서 오브젝트 이름이 맞으면 위치,방향,bool을 업데이트 해주는 형식
            {
                for (int j = 0; j < targets.Length; j++)
                {
                    if (SaveData.current.objList[i].name == targets[j].name)
                    {
                        string name = SaveData.current.objList[i].name;
                        GameObject obj = GameManager.Resource.Load<GameObject>($"Puzzle/{name}");
                        GameManager.Resource.Instantiate(obj, SaveData.current.objList[i].position, SaveData.current.objList[i].rotation);
                        targets[j].IsSokect = SaveData.current.objList[i].isIeventory;
                    }
                }
            }
        }

        public void RemoveObjList()        // 저장지우기
        {
            SaveData.current.objList.Remove(objData);
        }
    }
}

