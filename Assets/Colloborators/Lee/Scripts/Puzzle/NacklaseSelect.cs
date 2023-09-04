using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NacklaseSelect : MonoBehaviour
{
    [SerializeField] GameObject nacklase;
    [SerializeField] GameObject blackString;

    public void OnSelect() 
    {
        nacklase.SetActive(false);
        blackString.SetActive(true);
    }
}
