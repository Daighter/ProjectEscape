using System.Collections.Generic;
using UnityEngine;

namespace Jeong
{
    public class SoundManager : MonoBehaviour
    {
        Dictianary<string, AudioSource> mainRoomSounds;
        Dictionary<string, AudioSource> caveSound;
        Dictionary<string, AudioSource> elevatorSound;
        Dictionary<string, AudioSource> prisonSound;
        Dictionary<string, AudioSource> dungeonSound;
        

        private void Awake()
        {
            mainRoomSounds = new Dictianary<string, AudioSource>();
            caveSound = new Dictionary<string, AudioSource>();
            elevatorSound = new Dictionary<string, AudioSource>();
            prisonSound = new Dictionary<string, AudioSource>();
            dungeonSound = new Dictionary<string, AudioSource>();
        }
        
        // 메인룸 사운드
        #region
        public void AddMainRoomSound(string key, AudioSource audioSource)
        {
            if (ContainkeysMainRoomSound(key))
                RemoveMainRoomSound(key);
            mainRoomSounds.Add(key, audioSource);
        }

        public void RemoveMainRoomSound(string key)
        {
            mainRoomSounds.Remove(key);
        }

        public void PlayMainRoomSound(string key)
        {
            mainRoomSounds[key].Play();
        }

        public bool ContainkeysMainRoomSound(string key)
        {
            return mainRoomSounds.ContainsKey(key);
        }

        public void LogMainRoomSound(string key) // 디버그 로그 확인용
        {
            Debug.Log($"{key} Sound log");
        }
        #endregion

        // 엘레베이터 사운드
        #region Elevator
        public void AddElevatorSound(string key, AudioSource audioSource)
        {
            if (ContainkeysElevatorSound(key))
                RemoveElevatorSound(key);
            elevatorSound.Add(key, audioSource);
        }

        public void RemoveElevatorSound(string key)
        {
            elevatorSound.Remove(key);
        }

        public void PlayElevatorSound(string key)
        {
            elevatorSound[key].Play();
        }

        public bool ContainkeysElevatorSound(string key)
        {
            return elevatorSound.ContainsKey(key);
        }

        public void LogElevatorSound(string key) // 디버그 로그 확인용
        {
            Debug.Log($"{key} Sound log");
        }
        #endregion

        // 감옥 사운드
        #region Prison
        public void AddPrisonSound(string key, AudioSource audioSource)
        {
            if(ContainkeysPrisonSound(key))
                RemovePrisonSound(key);
            prisonSound.Add(key, audioSource);
        }

        public void RemovePrisonSound(string key)
        {
            prisonSound.Remove(key);
        }

        public void PlayPrisonSound(string key)
        {
            prisonSound[key].Play();
        }

        public bool ContainkeysPrisonSound(string key)
        {
            return prisonSound.ContainsKey(key);
        }

        public void LogPrisonSound(string key) // 디버그 로그 확인용
        {
            Debug.Log($"{key} Sound log");
        }
        #endregion

        // 던전 사운드
        #region Dungeon
        public void AddDungeonSound(string key, AudioSource audioSource)
        {
            if(ContainkeysDungeonSound(key))
                RemoveDungeonSound(key);
            dungeonSound.Add(key, audioSource);
        }

        public void RemoveDungeonSound(string key)
        {
            dungeonSound.Remove(key);
        }

        public void PlayDungeonSound(string key)
        {
            dungeonSound[key].Play();
        }

        public bool ContainkeysDungeonSound(string key)
        {
            return dungeonSound.ContainsKey(key);
        }

        public void LogDungeonSound(string key) // 디버그 로그 확인용
        {
            Debug.Log($"{key} Sound log");
        }
        #endregion

        // 동굴 사운드
        #region CaveSound
        public void AddCaveSound(string key, AudioSource audioSource)
        {
            if(ContainkeysCaveSound(key))
                RemoveCaveSound(key);
            caveSound.Add(key, audioSource);
        }

        public void RemoveCaveSound(string key)
        {
            caveSound.Remove(key);
        }

        public void PlayCaveSound(string key)
        {
            caveSound[key].Play();
        }

        public bool ContainkeysCaveSound(string key)
        {
            return caveSound.ContainsKey(key);
        }

        public void LogCaveSound(string key) // 디버그 로그 확인용
        {
            Debug.Log($"{key} Play");
        }
        #endregion
    }
}

