using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalObject : MonoBehaviour
{
    public string resourcePath;
    public string ResourcePath { get { return resourcePath; } set { resourcePath = value; } }
    public Vector3 position => transform.position;

    public Quaternion rotation => transform.rotation;
}
