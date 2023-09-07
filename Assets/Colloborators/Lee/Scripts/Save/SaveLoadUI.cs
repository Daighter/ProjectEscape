using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lee
{
    public class SaveLoadUI : MonoBehaviour
    {
        public void OnSave()
        {
            GameManager.Event.PostNotification(EventType.OnSave, this);
            SerializetionManager.Save("ObjectSave", SaveData.current);
        }

        public void OnLoad()
        {
            SaveData.current = (SaveData)SerializetionManager.Load(Application.persistentDataPath + "/saves/toysave.save");

            for(int i = 0; i<SaveData.current.objs.Count; i++) 
            {
                ObjectData objectData = SaveData.current.objs[i];
                //GameObject obj = Instantiate(objs[(int)objectData.objtype]);
                //InteratableObject interatableObject = obj.GetComponent<InteratableObject>();
                InteratableObject interatableObject = GetComponent<InteratableObject>();
                interatableObject.objData = objectData;
                interatableObject.transform.position = objectData.position;
                interatableObject.transform.rotation = objectData.rotation;
            }

        }


    }
}
