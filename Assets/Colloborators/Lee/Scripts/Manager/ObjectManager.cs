using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using static UnityEditor.Searcher.Searcher.AnalyticsEvent;


namespace Lee
{
    public enum SceneType
    {
        MainRoomScene,
        PrisonScene,
        Jeong,
        Bae,
    };

    public class ObjectManager : MonoBehaviour
    {
        public ObjectData objectData;

        private Dictionary<SceneType, List<ObjectData>> ObjLists = new Dictionary<SceneType, List<ObjectData>>();

        public void AddSceneObj()
        {
             //[] = FindObjectOfType<ObjectData>(); 해당씬에 있는 ObjectData 클래스가 있는 애들 배열에 담기
            string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            List<ObjectData> objList = null;

            switch (sceneName)
            {
                case "MainRoomScene":
                        if (ObjLists.TryGetValue(SceneType.MainRoomScene, out objList))
                            return;
                        objList = SaveData.current.objs;
                        ObjLists.Add(SceneType.MainRoomScene, objList);
                    break;

                case "PrisonScene":
                        if (ObjLists.TryGetValue(SceneType.PrisonScene, out objList))
                            return;
                    objList = SaveData.current.objs;
                    ObjLists.Add(SceneType.PrisonScene, objList);
                    break;

                case "Jeong":
                        if (ObjLists.TryGetValue(SceneType.Jeong, out objList))
                            return;
                    objList = SaveData.current.objs;
                    ObjLists.Add(SceneType.Jeong, objList);
                    break;

                case "Bae":
                        if (ObjLists.TryGetValue(SceneType.Bae, out objList))
                            return;
                    objList = SaveData.current.objs;
                    ObjLists.Add(SceneType.Bae, objList);
                    break;
            }
                
        }
        
        public void RemoveObjList()        // 저장지우기
        {
            SaveData.current.objs.Remove(objectData);
            ObjLists.Remove(SceneType.MainRoomScene);
            ObjLists.Remove(SceneType.PrisonScene);
            ObjLists.Remove(SceneType.Jeong);
            ObjLists.Remove(SceneType.Bae);
        }
    }
}
