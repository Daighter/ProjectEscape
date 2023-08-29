using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;
        private static ResourceManager resourceManager;
        private static DataManager dataManager;
        private static PoolManager poolManager;
        //private static UIManager uiManager;

        public static GameManager Instance { get { return instance; } }
        public static ResourceManager Resource { get { return resourceManager; } }
        public static DataManager Data { get { return dataManager; } }
        public static PoolManager Pool { get { return poolManager; } }
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
            resourceManager = resourceObj.AddComponent<ResourceManager>();

            GameObject dataObj = new GameObject() { name = "DataManager" };
            dataObj.transform.SetParent(transform);
            dataManager = dataObj.AddComponent<DataManager>();

            GameObject poolObj = new GameObject() { name = "PoolManager" };
            poolObj.transform.SetParent(transform);
            poolManager = poolObj.AddComponent<PoolManager>();
            /*
            GameObject uiObj = new GameObject() { name = "UIManager" };
            uiObj.transform.SetParent(transform);
            uiManager = uiObj.AddComponent<UIManager>();*/
        }
    }
}
