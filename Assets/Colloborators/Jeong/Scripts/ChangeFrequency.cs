using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace Jeong
{
    public class ChangeFrequency : MonoBehaviour
    {

        [SerializeField] GameObject Dial;

        Transform numPos;

        [SerializeField] float basePos;

        RadioDial radioDial;


        private void Start()
        {
            numPos = GetComponent<Transform>();
            radioDial = GetComponent<RadioDial>();

            basePos = 0f;

            Debug.Log($"numPos {numPos.position}");


            numPos.position = new Vector3(0.5f, basePos, 1.2f);
            Debug.Log($"numPos {numPos.position}");
        }

        private void OnEnable()
        {
            if(radioDial.value != 0)
            {
                basePos = radioDial.value;
                Debug.Log($"Dial value is {radioDial.value}");
            }  
        }
    }

}
