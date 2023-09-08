using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jeong
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] GameObject rock1;
        [SerializeField] GameObject rock2;
        [SerializeField] GameObject rock3;
        [SerializeField] GameObject rock4;
        [SerializeField] GameObject bomb;

        AudioSource bombAudio;

        private void Awake()
        {
            bombAudio = GetComponent<AudioSource>();
        }

        public void Delete()
        {
            if (rock1 && rock2 && rock3 && rock4 == null)
                return; 

            Debug.Log("Bomb");
            Destroy(bomb, 0.8f);
            Destroy(rock1, 1f);
            Destroy(rock2, 1.05f);
            Destroy(rock3, 1.10f);
            Destroy(rock4, 1.15f);
            Destroy(gameObject, 1.2f);

            // GameManager.Sound.PlayCaveBombSound("bombAudio");
            
        }
    }
}

