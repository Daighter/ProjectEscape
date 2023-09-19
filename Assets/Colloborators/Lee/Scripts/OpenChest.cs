using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public Quaternion rota;

    private void Awake()
    {
        rota = Quaternion.Euler(-120, 0, 0);
    }

    private void OnEnable()
    {
        if (GameManager.Data.isOpen == true)
            transform.localRotation = rota;
    }
}
