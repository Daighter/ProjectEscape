using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class MainRoomSoundPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip[] mainRoomSounds;
        public string[] soundKeyNames;

        private void Awake()
        {
            if (mainRoomSounds.Length > 0)
                soundKeyNames = new string[mainRoomSounds.Length];

            for (int i = 0; i < mainRoomSounds.Length; i++)
            {
                AudioSource ad = gameObject.AddComponent<AudioSource>();
                ad.clip = mainRoomSounds[i];
                ad.playOnAwake = false;

                soundKeyNames[i] = ad.clip.name;
                GameManager.Sound.AddMainRoomSound(soundKeyNames[i], ad);
            }
        }
    }
}
