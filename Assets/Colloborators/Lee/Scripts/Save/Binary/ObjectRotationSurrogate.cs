using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace Lee
{
    public class ObjectRotationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            Quaternion rota = (Quaternion)obj;
            info.AddValue("x", rota.x);
            info.AddValue("y", rota.y);
            info.AddValue("z", rota.z);
            info.AddValue("w", rota.w);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            Quaternion dir = (Quaternion)obj;
            dir.x = (float)info.GetValue("x", typeof(float));
            dir.y = (float)info.GetValue("y", typeof(float));
            dir.z = (float)info.GetValue("z", typeof(float));
            dir.w = (float)info.GetValue("w", typeof(float));
            obj = dir;
            return obj;
        }
    }

}