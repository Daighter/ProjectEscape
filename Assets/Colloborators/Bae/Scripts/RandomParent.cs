using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;


namespace Bae
{
    public class RandomParent : MonoBehaviour
    {
        public void RandomOn(GameObject[] obj, GameObject[] obj2)
        {
            int index = 0;
            while(index< obj2.Length)
            {
                bool duplicate = true;
                GameObject box = obj[Random.Range(0, obj.Length)];
                for (int i=0;i < obj2.Length;i++)
                {
                    if (obj2[i] == box)
                    {
                        duplicate = false;
                        break;
                    }
                }
                if(duplicate)
                {
                    obj2[index++] = box;
                }
            }
        }
    }
}

