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

        private Dictionary<SceneType, List<ObjectData>> Listers = new Dictionary<SceneType, List<ObjectData>>();

        public void AddSceneObj()
        {

             //[] = FindObjectOfType<ObjectData>(); 해당씬에 있는 ObjectData 클래스가 있는 애들 배열에 담기
            string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            List<ObjectData> objList = null;

            switch (sceneName)
            {
                case "MainRoomScene":
                        if (Listers.TryGetValue(SceneType.MainRoomScene, out objList))
                            return;
                        SaveData.current.objs.Add(objectData);
                        objList = SaveData.current.objs;
                        Listers.Add(SceneType.MainRoomScene, objList);
                    break;

                case "PrisonScene":
                        if (Listers.TryGetValue(SceneType.PrisonScene, out objList))
                            return;
                    SaveData.current.objs.Add(objectData);
                    objList = SaveData.current.objs;
                    Listers.Add(SceneType.PrisonScene, objList);
                    break;

                case "Jeong":
                        if (Listers.TryGetValue(SceneType.Jeong, out objList))
                            return;
                    SaveData.current.objs.Add(objectData);
                    objList = SaveData.current.objs;
                    Listers.Add(SceneType.Jeong, objList);
                    break;

                case "Bae":
                        if (Listers.TryGetValue(SceneType.Bae, out objList))
                            return;
                    SaveData.current.objs.Add(objectData);
                    objList = SaveData.current.objs;
                    Listers.Add(SceneType.Bae, objList);
                    break;
            }
                
        }
        
        public void RemoveObjList()        // 저장지우기
        {
            SaveData.current.objs.Remove(objectData);
            Listers.Remove(SceneType.MainRoomScene);
            Listers.Remove(SceneType.PrisonScene);
            Listers.Remove(SceneType.Jeong);
            Listers.Remove(SceneType.Bae);
        }
    }
}
