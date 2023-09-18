using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Jeong
{
    public class LantonPositionNum : MonoBehaviour
    {
        TextMeshProUGUI lantonPosition;
        

        private void Awake()
        {
            lantonPosition = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            LantonPositionUI();
        }

        public void LantonPositionUI()
        {
            int lantonPos1 = GameManager.Data.caveTime[0];
            int lantonPos2 = GameManager.Data.caveTime[1];
            int lantonPos3 = GameManager.Data.caveTime[2];
            lantonPosition.text = $" LantonPos1 = {lantonPos1}\n LantonPos2 = {lantonPos2}\n LantonPos3 = {lantonPos3}";
        }
    }

}
