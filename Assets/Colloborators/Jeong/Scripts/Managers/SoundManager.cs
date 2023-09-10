using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jeong
{
    public class SoundManager : MonoBehaviour
    {
        Dictionary<string, AudioSource> caveSound;
        Dictionary<string, AudioSource> elevatorSound;
        Dictionary<string, AudioSource> prisonSound;
        Dictionary<string, AudioSource> dungeonSound;

        private void Awake()
        {
            caveSound = new Dictionary<string, AudioSource>();
            elevatorSound = new Dictionary<string, AudioSource>();
            prisonSound = new Dictionary<string, AudioSource>();
            dungeonSound = new Dictionary<string, AudioSource>();
        }

        // 엘레베이터 사운드
        #region Elevator
        public void AddElevatorSound(string name, AudioSource audioSource)
        {
            if (ContainkeysElevatorSound(name))
                RemoveElevatorSound(name);
            elevatorSound.Add(name, audioSource);
        }

        public void RemoveElevatorSound(string name)
        {
            elevatorSound.Remove(name);
        }

        public void PlayElevatorSound(string name)
        {
            elevatorSound[name].Play();
        }

        public bool ContainkeysElevatorSound(string name)
        {
            return elevatorSound.ContainsKey(name);
        }

        public void LogElevatorSound(string name) // 디버그 로그 확인용
        {
            Debug.Log($"{name} Sound log");
        }
        #endregion

        // 감옥 사운드
        #region Prison
        public void AddPrisonSound(string name, AudioSource audioSource)
        {
            if(ContainkeysPrisonSound(name))
                RemovePrisonSound(name);
            prisonSound.Add(name, audioSource);
        }

        public void RemovePrisonSound(string name)
        {
            prisonSound.Remove(name);
        }

        public void PlayPrisonSound(string name)
        {
            prisonSound[name].Play();
        }

        public bool ContainkeysPrisonSound(string name)
        {
            return prisonSound.ContainsKey(name);
        }

        public void LogPrisonSound(string name) // 디버그 로그 확인용
        {
            Debug.Log($"{name} Sound log");
        }
        #endregion

        // 던전 사운드
        #region Dungeon
        public void AddDungeonSound(string name, AudioSource audioSource)
        {
            if(ContainkeysDungeonSound(name))
                RemoveDungeonSound(name);
            dungeonSound.Add(name, audioSource);
        }

        public void RemoveDungeonSound(string name)
        {
            dungeonSound.Remove(name);
        }

        public void PlayDungeonSound(string name)
        {
            dungeonSound[name].Play();
        }

        public bool ContainkeysDungeonSound(string name)
        {
            return dungeonSound.ContainsKey(name);
        }

        public void LogDungeonSound(string name) // 디버그 로그 확인용
        {
            Debug.Log($"{name} Sound log");
        }
        #endregion

        // 동굴 사운드
        #region CaveSound
        public void AddCaveSound(string name, AudioSource audioSource)
        {
            if(ContainkeysCaveSound(name))
                RemoveCaveSound(name);
            caveSound.Add(name, audioSource);
        }

        public void RemoveCaveSound(string name)
        {
            caveSound.Remove(name);
        }

        public void PlayCaveSound(string name)
        {
            caveSound[name].Play();
        }

        public bool ContainkeysCaveSound(string name)
        {
            return caveSound.ContainsKey(name);
        }

        public void LogCaveSound(string name) // 디버그 로그 확인용
        {
            Debug.Log($"{name} Play");
        }
        #endregion
    }
}

