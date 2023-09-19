using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Bae
{
    public class RandomRune : RandomParent
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
            RandomOn(runes, GameManager.Data.runeBox);
            RuneAttach();
        }
        public void RuneAttach()
        {
            
            for(int i = 0; i < runeMarks.Length; i++)
            {
                GameObject rune = GameManager.Data.runeBox[i];
                Instantiate(rune, runeMarks[i].transform);
                rune.transform.localPosition = Vector3.zero;
            }
        }
    }
}
