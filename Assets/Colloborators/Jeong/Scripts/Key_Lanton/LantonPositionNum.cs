using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Jeong
{
    public class LantonPositionNum : MonoBehaviour
    {
       /* TextMeshProUGUI lantonPosition;

        private void Awake()
        {
            lantonPosition = GetComponent<TextMeshProUGUI>();
        }*/

        private void Start()
        {
            StartCoroutine(LantonPositionUI());
        }

        public IEnumerator LantonPositionUI()
        {
            yield return new WaitForSeconds(2f);
            int lantonPos1 = GameManager.Data.caveTime[0];
            int lantonPos2 = GameManager.Data.caveTime[1];
            int lantonPos3 = GameManager.Data.caveTime[2];

            /*if (lantonPos2 != 12 || lantonPos3 != 12)
            {
                if (lantonPos2 != 1 || lantonPos3 != 1)
                    lantonPosition.text = $" {lantonPos1}h : {lantonPos2 * 5}m : {lantonPos3 * 5}s";
                if (lantonPos2 == 1 && lantonPos3 != 1)
                    lantonPosition.text = $" {lantonPos1}h : 05m : {lantonPos3 * 5}s";
                if (lantonPos2 != 1 && lantonPos3 == 1)
                    lantonPosition.text = $" {lantonPos1}h : {lantonPos2 * 5}m : 05s";
            }
                
            if (lantonPos2 == 12 && lantonPos3 != 12)
            {
                if (lantonPos2 != 1 || lantonPos3 != 1)
                    lantonPosition.text = $" {lantonPos1}h : 00m : {lantonPos3 * 5}s";
                if (lantonPos2 != 1 && lantonPos3 == 1)
                    lantonPosition.text = $" {lantonPos1}h : 00m : 05s";
                else
                    lantonPosition.text = $" {lantonPos1}h : 00m : {lantonPos3 * 5}s";
            }
               
            if (lantonPos2 != 12 && lantonPos3 == 12)
            {
                if (lantonPos2 != 1 || lantonPos3 != 1)
                    lantonPosition.text = $" {lantonPos1}h : {lantonPos2 * 5}m : 00s";
                if (lantonPos2 == 1 && lantonPos3 != 1)
                    lantonPosition.text = $" {lantonPos1}h : 05m : 00s";
                else 
                    lantonPosition.text = $" {lantonPos1}h : {lantonPos2 * 5}m : 00s";
            }*/
        }
    }
}
