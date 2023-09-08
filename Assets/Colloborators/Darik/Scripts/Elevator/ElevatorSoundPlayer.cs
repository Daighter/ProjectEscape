using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class ElevatorSoundPlayer : MonoBehaviour
    {
        [SerializeField] AudioSource[] sounds;

        /* sounds[0] : OpenSound
         * sounds[1] : CloseSound
         * sounds[2] : GoUpSound
         * sounds[3] : GoDawnSound
         */

        private string[] keys = new string[4];

        private void Awake()
        {
            Keys();

            for (int i = 0; i < sounds.Length; i++)
            {
                if (!GameManager.Sound.elevatorSound.ContainsKey(keys[i]))
                    GameManager.Sound.AddElevatorSound(keys[i], sounds[i]);
            }
        }

        private void Keys()
        {
            keys[0] = "OpenSound";
            keys[1] = "CloseSound";
            keys[2] = "GoUpSound";
            keys[3] = "GoDawnSound";
        }

        public void PlayOpenSound()
        {
            GameManager.Sound.PlayElevatorSound("OpenSound");
        }

        public void PlayCloseSound()
        {
            GameManager.Sound.PlayElevatorSound("CloseSound");
        }

        public void PlayGoUpSound()
        {
            GameManager.Sound.PlayElevatorSound("GoUpSound");
        }

        public void PlayGoDawnSound()
        {
            GameManager.Sound.PlayElevatorSound("GoDawnSound");
        }
    }
}
