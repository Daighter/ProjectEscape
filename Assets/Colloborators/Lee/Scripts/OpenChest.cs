using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public Quaternion rota;
    private bool isOpen;
    public bool IsOpen { get { return isOpen; } set { isOpen = value; } }

    private void Awake()
    {
        rota = Quaternion.Euler(-120, 0, 0);
    }

    private void OnEnable()
    {
        if (isOpen == true)
            transform.localRotation = rota;
    }

    public void Open()
    {
        isOpen = true;
    }
}
