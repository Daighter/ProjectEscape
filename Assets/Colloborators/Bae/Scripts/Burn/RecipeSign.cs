using Jeong;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Bae
{
    public class RecipeSign : MonoBehaviour
    {
        [SerializeField] TMP_Text Text;
        [SerializeField] GameObject caveHint;

        private void OnEnable()
        {
            if(GameManager.Data.isCaveLantonClear)
            {
                caveHint.SetActive(false);
            }
        }

        private void Start()      
        {
            
          Text.text = $"{GameManager.Data.recipeDolls[0].name}\n{GameManager.Data.recipeDolls[1].name}\n{GameManager.Data.recipeDolls[2].name}";
        }
       
    }
}

