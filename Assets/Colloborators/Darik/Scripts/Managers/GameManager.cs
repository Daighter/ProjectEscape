using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private static Darik.ResourceManager resourceManager;
    private static Darik.PoolManager poolManager;
    private static Darik.DataManager dataManager;
    private static Darik.SceneManager sceneManager;
    private static Bae.UIManager uiManager;
    private static Jeong.SoundManager soundManager;
    private static Lee.EventManager eventManager;
    private static Lee.SaveManager_Binary saveManager;
    private static Lee.ObjectSaveManager objectSaveManager;

    public static GameManager Instance { get { return instance; } }
    public static Darik.ResourceManager Resource { get { return resourceManager; } }
    public static Darik.DataManager Data { get { return dataManager; } }
    public static Darik.PoolManager Pool { get { return poolManager; } }
    public static Darik.SceneManager Scene { get { return sceneManager; } }
    public static Bae.UIManager UI { get { return uiManager; } }
    public static Jeong.SoundManager Sound { get { return soundManager; } }
    public static Lee.EventManager Event { get { return eventManager; } }
    public static Lee.SaveManager_Binary Save { get { return saveManager; } }
    public static Lee.ObjectSaveManager ObjM { get { return objectSaveManager; } } 

    private void Awake()            // 유니티용 중복제거
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this);
        instance = this;
        InitManagers();
    }

    private void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }

    private void InitManagers()
    {
        // 게임을 시작하기 전 필요한 설정들
        GameObject resourceObj = new GameObject() { name = "ResourceManager" };
        resourceObj.transform.SetParent(transform);
        resourceManager = resourceObj.AddComponent<Darik.ResourceManager>();

        GameObject dataObj = new GameObject() { name = "DataManager" };
        dataObj.transform.SetParent(transform);
        dataManager = dataObj.AddComponent<Darik.DataManager>();

        GameObject poolObj = new GameObject() { name = "PoolManager" };
        poolObj.transform.SetParent(transform);
        poolManager = poolObj.AddComponent<Darik.PoolManager>();

        GameObject sceneObj = new GameObject() { name = "SceneManager" };
        sceneObj.transform.SetParent(transform);
        sceneManager = sceneObj.AddComponent<Darik.SceneManager>();

        GameObject uiObj = new GameObject() { name = "UIManager" };
        uiObj.transform.SetParent(transform);
        uiManager = uiObj.AddComponent<Bae.UIManager>();

        GameObject soundObj = new GameObject() { name = "SoundManager" };
        soundObj.transform.SetParent(transform);
        soundManager = soundObj.AddComponent<Jeong.SoundManager>();

        GameObject eventObj = new GameObject() { name = "EventManager" };
        eventObj.transform.SetParent(transform);
        eventManager = eventObj.AddComponent<Lee.EventManager>();

        GameObject saveObj = new GameObject() { name = "SaveManager" };
        saveObj.transform.SetParent(transform);
        saveManager = saveObj.AddComponent<Lee.SaveManager_Binary>();

        GameObject ObjMObj = new GameObject() { name = "ObjMManager" };
        ObjMObj.transform.SetParent(transform);
        objectSaveManager = ObjMObj.AddComponent<Lee.ObjectSaveManager>();
    }
}