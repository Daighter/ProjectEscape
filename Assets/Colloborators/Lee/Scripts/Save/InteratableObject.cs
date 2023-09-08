using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Lee
{
    public class InteratableObject : MonoBehaviour, IEventListener
    {
        public ObjectData objData;

        public void Start()
        {
            if (string.IsNullOrEmpty(objData.id))
            {
                objData.id = System.DateTime.Now.ToLongDateString() + System.DateTime.Now.ToLongTimeString() + Random.Range(0, int.MaxValue).ToString();
                SaveData.current.objs.Add(objData);
            }
            objData.id = gameObject.name;
        }

        public void OnEnable()
        {
            GameManager.Event.AddListener(EventType.OnSave, this);
        }

        public void DataBackUp()
        {
            objData.position = transform.position;
            objData.rotation = transform.rotation;
        }

        public void ObjDestroy()    // ���� ������Ʈ ������Ʈ ����� ������ ������� �� �Լ��� �̿��ؼ� ������ ����� ������� ��ȯ
        {
            Destroy(gameObject);
        }

        public void OnEvent(EventType eventType, Component Sender, object Param = null) // ���� �̺�Ʈ �߻��� ��ġ,������ Data�� ����
        {
            if(eventType == EventType.OnSave)
            {
                DataBackUp();
            }

            //if(eventType == EventType.OnLoad) // �ҷ��ý� �����ϰ� �ٽ� �����ϴ� �������� �����ϱ�
            //{
            //    ObjDestroy();
            //}
        }
    }

}