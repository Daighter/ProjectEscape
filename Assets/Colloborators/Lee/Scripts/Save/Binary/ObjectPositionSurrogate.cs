using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace Lee
{
    public class ObjectPositionSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            Vector3 dir = (Vector3)obj;
            info.AddValue("x", dir.x);
            info.AddValue("y", dir.y);
            info.AddValue("z", dir.z);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            Vector3 dir = (Vector3)obj;
            dir.x = (float)info.GetValue("x", typeof(float));
            dir.y = (float)info.GetValue("y", typeof(float));
            dir.z = (float)info.GetValue("z", typeof(float));
            obj = dir;
            return obj;
        }
    }
}
