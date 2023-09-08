using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bae
{
    public class RuneActive : MonoBehaviour
    {
        [SerializeField] public List<GameObject> runes;

        public void RunesActive()
        {
           foreach(GameObject rune in runes)
            {
                rune.SetActive(true);
            }
        }
    }
}

