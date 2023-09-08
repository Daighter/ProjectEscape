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
            rock1.SetActive(true);
            rock2.SetActive(true);
            rock3.SetActive(true);
            rock4.SetActive(true);
            rock5.SetActive(true);
            rock6.SetActive(true);
            rock7.SetActive(true);
            gameObject.SetActive(true);
        }

        public void Delete()
        {
            if (rock1 && rock2 && rock3 && rock4 && rock5 && rock6 && rock7 == null)
                return; 

            lanton.SetActive(true);
            Debug.Log("Bomb");
            bomb.SetActive(false);
            rock1.SetActive(false);
            rock2.SetActive(false);
            rock3.SetActive(false);
            rock4.SetActive(false);
            rock5.SetActive(false);
            rock6.SetActive(false);
            rock7.SetActive(false);
            gameObject.SetActive(false);

            // GameManager.Sound.PlayCaveBombSound("bombAudio");
            
        }
    }
}

