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
        [SerializeField] LantonLinkGimmick lantonLinkGimmick;

        private void Awake()
        {
            lantonPosition = GetComponent<TextMeshProUGUI>();
        }
      
        public void LantonPositionUI()
        {
            int lantonPos1 = lantonLinkGimmick.caveTime[0];
            int lantonPos2 = lantonLinkGimmick.caveTime[1];
            int lantonPos3 = lantonLinkGimmick.caveTime[2];
            lantonPosition.text = $" LantonPos1 = {lantonPos1}\n LantonPos2 = {lantonPos2}\n LantonPos3 = {lantonPos3}";
        }
    }

}
