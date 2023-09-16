using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bae
{
    public class RandomRune : MonoBehaviour
    {
        [SerializeField] GameObject[] runes;
        [SerializeField] GameObject[] runeMarks;
        [SerializeField] GameObject[] runeBox=new GameObject[4];
        private void Awake()
        {
            if (runeBox[0]!=null)
            {
                RuneAttach();
                return;
            }
            int runeIndex = 0;
            bool runeNull=true;
            while(runeIndex < runeBox.Length)
            {
                GameObject rune = runes[Random.Range(0, runes.Length)];
                for (int i = 0; i < runeBox.Length; i++)
                {
                    if (runeBox[i] == rune)
                    {
                        runeNull = false;
                        break;
                    }
                }
                if(runeNull)
                {
                    runeBox[runeIndex] = rune;
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
                runeBox[i].transform.parent = runeMarks[i].transform;
                runeBox[i].transform.localPosition = Vector3.zero;
            }
        }
    }
}
