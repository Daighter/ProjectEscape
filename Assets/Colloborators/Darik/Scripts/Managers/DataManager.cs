using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class DataManager : MonoBehaviour
    {
        private string[] dolls = { "", "", "", "", "", "" };
        private int[] times = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

        public string[] recipeDolls = new string[3];

        public int[] caveTime = new int[3];
        public bool isCaveClear = false;
    }
}
