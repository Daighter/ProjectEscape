using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventListener
{
    //이벤트 발생시 전송되는 이벤트 정보.
    public void OnEvent(EventType eventType, Component Sender, object Param = null);

    // 이벤트 발생 확인용 코드
    /*
    string result = string.Format("받은 이벤트 종류 :  {0}, 이벤트 전달한 오브젝트 : {1}", eventType, Sender.gameObject.name.ToString());
    Debug.Log(result);
    */
}
