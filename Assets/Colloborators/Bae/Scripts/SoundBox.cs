using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bae
{
    public class SoundBox : MonoBehaviour
    {
        [SerializeField] AudioClip[] audioClips;

        AudioSource[] dungeonAudio;
        private void Awake()
        {
            dungeonAudio=new AudioSource[audioClips.Length];
            AudioSourceMake();
            for(int i=0;i<audioClips.Length;i++)
            {
                GameManager.Sound.AddDungeonSound(audioClips[i].name, dungeonAudio[i]);
            }
        }
        private void AudioSourceMake()
        {
            for (int i = 0; i < audioClips.Length; i++)
            {
                dungeonAudio[i] = gameObject.AddComponent<AudioSource>();
                dungeonAudio[i].clip = audioClips[i];
                dungeonAudio[i].playOnAwake = false;
            }
        }
    }
}

