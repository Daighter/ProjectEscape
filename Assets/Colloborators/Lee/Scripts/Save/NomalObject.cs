using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UIElements;

public class NomalObject : MonoBehaviour
{
    private string chilenName;
    private bool objActive;
    public bool ObjActive {get { return objActive;} set { objActive = value; gameObject.SetActive(objActive); } }
    private void Start()
    {
        objActive = true;
    }

    //private void OnEnable()
    //{
    //    objActive = true;
    //}

    private void OnDisable()
    {
        objActive = false;
    }

}
