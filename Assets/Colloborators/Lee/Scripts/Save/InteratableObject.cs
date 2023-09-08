using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Lee
{
    public class InteratableObject : MonoBehaviour, IEventListener
    {
        public ObjectData objData;

        private void Start()
        {
            objData.id = gameObject.name;

            SaveData.current.objs.Add(objData);
        }
        public void OnEnable()
        {
            GameManager.Event.AddListener(EventType.OnSave, this);
            GameManager.Event.AddListener(EventType.OnLoad, this);
        }

        public void DataSave()
        {
            objData.position = transform.position;
            objData.rotation = transform.rotation;
        }

        public void DataLoad()
        {
            transform.position = objData.position;
            transform.rotation = objData.rotation;
        }

        public void OnEvent(EventType eventType, Component Sender, object Param = null) // ���� �̺�Ʈ �߻��� ��ġ,������ Data�� ����
        {
            if(eventType == EventType.OnSave)
            {
                DataSave();
            }

            if (eventType == EventType.OnLoad)
            {
                DataLoad();
            }
        }
    }

}