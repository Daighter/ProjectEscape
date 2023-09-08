using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jeong
{
    public class SoundManager : MonoBehaviour
    {
        Dictionary<string, AudioSource> caveRoomSound;
        Dictionary<string, AudioSource> elevatorSound;
        Dictionary<string, AudioSource> prisonSound;
        Dictionary<string, AudioSource> dungeonSound;

        private void Awake()
        {
            caveRoomSound = new Dictionary<string, AudioSource>();
            elevatorSound = new Dictionary<string, AudioSource>();
            prisonSound = new Dictionary<string, AudioSource>();
            dungeonSound = new Dictionary<string, AudioSource>();
        }

        // ���������� ����
        #region Elevator
        public void AddElevatorSound(string name, AudioSource audioSource)
        {
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

        public void LogElevatorSound(string name) // ����� �α� Ȯ�ο�
        {
            Debug.Log($"{name} Sound log");
        }
        #endregion

        // ���� ����
        #region Prison
        public void AddPrisonSound(string name, AudioSource audioSource)
        {
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

        public void LogPrisonSound(string name) // ����� �α� Ȯ�ο�
        {
            Debug.Log($"{name} Sound log");
        }
        #endregion

        // ���� ����
        #region Dungeon
        public void AddDungeonSound(string name, AudioSource audioSource)
        {
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

        public void LogDungeonSound(string name) // ����� �α� Ȯ�ο�
        {
            Debug.Log($"{name} Sound log");
        }
        #endregion

        // ���� ����
        #region CaveSound
        public void AddCaveRadioSound(string name, AudioSource audioSource)
        {
            caveRoomSound.Add(name, audioSource);
        }

        public void RemoveCaveRadioSound(string name)
        {
            caveRoomSound.Remove(name);
        }

        public void PlayCaveRadioSound(string name)
        {
            caveRoomSound[name].Play();
        }

        public void LogCaveRadioSound(string name) // ����� �α� Ȯ�ο�
        {
            Debug.Log($"{name} Play");
        }
        #endregion
    }
}

