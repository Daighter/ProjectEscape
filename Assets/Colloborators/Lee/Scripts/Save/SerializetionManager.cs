using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Lee
{
    public class SerializetionManager : MonoBehaviour
    {
        public static bool Save(string saveName, object saveData)
        {
            BinaryFormatter formatter = GetBinaryFormatter();

            if(!Directory.Exists(Application.persistentDataPath + "/saves"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/saves");
            }

            string path = Application.persistentDataPath + "/saves" + saveName + ".save";

            FileStream file = File.Create(path);

            formatter.Serialize(file, saveData);

            file.Close();

            return true;
        }

        public static object Load(string path)
        {
            if(!File.Exists(path))
            {
                return null;
            }

            BinaryFormatter formatter = GetBinaryFormatter();

            FileStream file = File.Open(path, FileMode.Open);

            try
            {
                object save = formatter.Deserialize(file);
                file.Close();
                return save;
            }
            catch
            {
                Debug.LogErrorFormat("파일을 불러오는데 실패하였습니다", path);
                file.Close() ;
                return null;
            }
        }

        public static BinaryFormatter GetBinaryFormatter() 
        {
            BinaryFormatter formatter = new BinaryFormatter();

            SurrogateSelector selector = new SurrogateSelector();

            ObjectPositionSurrogate objectPosition = new ObjectPositionSurrogate();

            ObjectRotationSurrogate objectRotation = new ObjectRotationSurrogate();

            selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), objectPosition);
            selector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), objectRotation);

            formatter.SurrogateSelector = selector;

            return formatter;
        }
    }
}
