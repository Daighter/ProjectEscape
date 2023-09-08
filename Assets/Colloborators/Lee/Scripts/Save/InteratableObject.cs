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

        public void ObjDestroy()    // 기존 오브젝트 업데이트 방식이 문제가 있을경우 이 함수를 이용해서 삭제후 재생성 방식으로 전환
        {
            Destroy(gameObject);
        }

        public void OnEvent(EventType eventType, Component Sender, object Param = null) // 저장 이벤트 발생시 위치,방향을 Data에 담음
        {
            if(eventType == EventType.OnSave)
            {
                DataBackUp();
            }

            //if(eventType == EventType.OnLoad) // 불러올시 삭제하고 다시 생성하는 과정으로 설계하기
            //{
            //    ObjDestroy();
            //}
        }
    }

}