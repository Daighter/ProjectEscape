using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jeong
{
    public class LantonSoundController : MonoBehaviour
    {
        [SerializeField] AudioSource[] caveLantonAudio;

        private string[] key = new string[1];

        private void Awake()
        {
            Keys();
            for (int i = 0; i < key.Length; i++)
            {
                GameManager.Sound.AddCaveSound(key[i], caveLantonAudio[i]);
            }
        }

        private void Keys()
        {
            key[0] = "LantonHangOnSound";
        }

        public void LantonHangOn()
        {
            GameManager.Sound.PlayCaveSound("LantonHangOnSound");
        }
        public void LantonHangOff()
        {
            GameManager.Sound.PlayCaveSound("LantonHangOnSound");
        }
    }

}
