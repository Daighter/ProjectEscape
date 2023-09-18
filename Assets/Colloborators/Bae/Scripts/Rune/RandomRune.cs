using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bae
{
    public class RandomRune : MonoBehaviour
    {
        [SerializeField] GameObject[] runes;
        [SerializeField] GameObject[] runeMarks;
        private void Awake()
        {
            if (GameManager.Data.runeBox[0]!=null)
            {
                RuneAttach();
                return;
            }
            int runeIndex = 0;
            bool runeNull=true;
            while(runeIndex < GameManager.Data.runeBox.Length)
            {
                GameObject rune = runes[Random.Range(0, runes.Length)];
                for (int i = 0; i < GameManager.Data.runeBox.Length; i++)
                {
                    if (GameManager.Data.runeBox[i] == rune)
                    {
                        runeNull = false;
                        break;
                    }
                }
                if(runeNull)
                {
                    GameManager.Data.runeBox[runeIndex] = rune;
                    runeIndex++;
                    Debug.Log(runeIndex);
                }

                runeNull = true;
            }
            RuneAttach();
        }
        public void RuneAttach()
        {
            for(int i = 0; i < runeMarks.Length; i++)
            {
                GameManager.Data.runeBox[i].transform.parent = runeMarks[i].transform;
                GameManager.Data.runeBox[i].transform.localPosition = Vector3.zero;
            }
        }
    }
}
