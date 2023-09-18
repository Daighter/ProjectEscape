using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace Bae
{
    public class RuneActive : MonoBehaviour
    {
        [SerializeField] List<GameObject> runes;
        [SerializeField] List<ParticleSystem> particle;
        public void RunesActive()
        {
            GameManager.Sound.PlayDungeonSound("JewelSocket");
            StartCoroutine(RuneEffect());
        }
        IEnumerator RuneEffect()
        {
            foreach(ParticleSystem par in particle)
            {
                par.Play();
            }
            yield return new WaitForSeconds(2f);
            foreach (GameObject rune in runes)
            {
                rune.SetActive(true);
            }
        }
    }
}

