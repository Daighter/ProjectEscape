using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Jeong 
{
    public class RadioUi : MonoBehaviour
    {
        public TextMeshProUGUI radioMessage;
        private string tx = "Rescue team will arrive soon.\r\ncheck the nearest wall.";
        
        public IEnumerator radioUiRoutine()
        {
            yield return new WaitForSeconds(2f);
            for(int i = 0; i < tx.Length; i++) 
            {
                radioMessage.text = tx.Substring(0, i);

                yield return new WaitForSeconds(0.1f);
            }
        }
    }

}

