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
    //private static UIManager uiManager;

    public static GameManager Instance { get { return instance; } }
    public static Darik.ResourceManager Resource { get { return resourceManager; } }
    public static Darik.DataManager Data { get { return dataManager; } }
    public static Darik.PoolManager Pool { get { return poolManager; } }
    public static Darik.SceneManager Scene { get { return sceneManager; } }
    //public static UIManager UI { get { return uiManager; } }

    private void Awake()            // ����Ƽ�� �ߺ�����
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
        // ������ �����ϱ� �� �ʿ��� ������
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

        /*
        GameObject uiObj = new GameObject() { name = "UIManager" };
        uiObj.transform.SetParent(transform);
        uiManager = uiObj.AddComponent<UIManager>();*/
    }
}