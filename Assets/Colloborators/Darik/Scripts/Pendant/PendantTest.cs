using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendantTest : MonoBehaviour
{
    public void OnHoverEnter()
    {
        Debug.Log("HoverEnter");
    }

    public void OnHoverExit()
    {
        Debug.Log("HoverExit");
    }

    public void OnSelectEnter()
    {
        Debug.Log("SelectEnter");
    }

    public void OnSelectExit()
    {
        Debug.Log("SelectExit");
    }
}
