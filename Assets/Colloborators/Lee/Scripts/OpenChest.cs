using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public Vector3 rota;

    private void Awake()
    {
        rota = transform.rotation.eulerAngles;
    }

    private void Start()
    {
        StartCoroutine(Open());
    }


    IEnumerator Open()
    {
        
        yield return new WaitForSeconds(3f);
        transform.localRotation = Quaternion.Euler(-120,0,0);
    }
}
