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
        private string tx1 = "........................";
        private string tx2 = "Rescue team will arrive soon.\r\ncheck the nearest wall.";

        public IEnumerator radioUiRoutine1()
        {
            yield return new WaitForSeconds(0.1f);
            for (int i = 0; i < tx1.Length; i++)
            {
                radioMessage.text = tx1.Substring(0, i);
                yield return new WaitForSeconds(0.05f);
            }
        }

        public IEnumerator radioUiRoutine2()
        {
            yield return new WaitForSeconds(1.5f);
            for(int i = 0; i < tx2.Length; i++) 
            {
                radioMessage.text = tx2.Substring(0, i);
                yield return new WaitForSeconds(0.05f);
            }
        }
    }

}

