using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalObject : MonoBehaviour
{
    private bool objActive;

    public bool ObjActive {get { return objActive;} set { objActive = value; } }    

    private Vector3 position;
    public Vector3 Position { get { return position; } set { position = value; } }

    private Quaternion rotation;
    public Quaternion Rotation { get { return rotation; } set { rotation = value; } }

    private void Start()
    {
        if(objActive==false)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        objActive = true;
    }

    private void OnDisable()
    {
        objActive = false;
    }

}
