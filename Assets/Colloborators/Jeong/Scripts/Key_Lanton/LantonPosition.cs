using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Jeong
{
    public class LantonPosition : MonoBehaviour
    {
        TextMeshPro lantonPosition;
        [SerializeField]LantonLinkGimmick lantonLinkGimmick;

        private void Awake()
        {
            lantonPosition = GetComponent<TextMeshPro>();
        }

        private void Start()
        {
            LantonPositionUI();
        }

        public void LantonPositionUI()
        {
            int lantonPos1 = lantonLinkGimmick.caveTime[0];
            int lantonPos2 = lantonLinkGimmick.caveTime[1];
            int lantonPos3 = lantonLinkGimmick.caveTime[2];
            Debug.Log(lantonPos1);
            Debug.Log(lantonPos2);
            Debug.Log(lantonPos3);
            lantonPosition.text = $"{lantonPos1}\n {lantonPos2}\n {lantonPos3}";
            Debug.Log($"{lantonPosition.text}");
        }
    }

}
