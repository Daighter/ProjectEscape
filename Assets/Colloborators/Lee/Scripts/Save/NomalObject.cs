using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NomalObject : MonoBehaviour
{
    private bool objActive;
    public bool ObjActive {get { return objActive;} set { objActive = value; gameObject.SetActive(objActive); } }    

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
