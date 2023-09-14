using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class Stair1FDoorPuzzle : MonoBehaviour
    {
        [SerializeField] private GameObject stair1FDoor;

        public bool IsDungeonRoomClear { get; set; }
        public bool IsPrisonRoomClear { get; set; }
        public bool IsCaveRoomClear { get; set; }
        public bool IsColorMatchClear { get; set; }

        public void CheckAllClear()
        {
            if (IsDungeonRoomClear && IsPrisonRoomClear && IsCaveRoomClear && IsColorMatchClear)
                stair1FDoor.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
    }
}

