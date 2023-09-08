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
        [SerializeField] GameObject rock5;
        [SerializeField] GameObject rock6;
        [SerializeField] GameObject rock7;
        [SerializeField] GameObject bomb;
        [SerializeField] GameObject lanton;

        AudioSource bombAudio;

        private void Awake()
        {
            bombAudio = GetComponent<AudioSource>();
        }

        private void Start()
        {
            lanton.SetActive(false);
        }

        public void Delete()
        {
            if (rock1 && rock2 && rock3 && rock4 && rock5 && rock6 && rock7 == null)
                return; 

            lanton.SetActive(true);
            Debug.Log("Bomb");
            Destroy(bomb, 2.5f);
            Destroy(rock1, 3.3f);
            Destroy(rock2, 3.5f);
            Destroy(rock3, 3.7f);
            Destroy(rock4, 3.9f);
            Destroy(rock5, 4.1f);
            Destroy(rock6, 4.3f);
            Destroy(rock7, 4.5f);
            Destroy(gameObject, 4.5f);


            // GameManager.Sound.PlayCaveBombSound("bombAudio");
            
        }
    }
}

