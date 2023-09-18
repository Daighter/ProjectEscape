using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Darik
{
    public class Stair1FDoorPuzzle : MonoBehaviour
    {
        [SerializeField] private GameObject stair1FDoor;
        [SerializeField] private Image KeyImage;

        public bool IsDungeonRoomClear { get; set; }
        public bool IsPrisonRoomClear { get; set; }
        public bool IsCaveRoomClear { get; set; }
        public bool IsColorMatchClear { get; set; }

        private void Start()
        {
            if (GameManager.Data.isCorridorDoorOpen)
                stair1FDoor.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            else
                stair1FDoor.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        public void CheckAllClear()
        {
            if (!GameManager.Data.isCorridorDoorOpen)
            {
                if (IsDungeonRoomClear && IsPrisonRoomClear && IsCaveRoomClear && IsColorMatchClear)
                {
                    GameManager.Data.isCorridorDoorOpen = true;
                    stair1FDoor.transform.rotation = Quaternion.Euler(0f, -90f, 0f);

                    KeyImage.gameObject.SetActive(false);
                    GameObject facilityKey = GameManager.Resource.Instantiate(GameManager.Resource.Load<GameObject>("Prefabs/Puzzles/Keys/FacilityRoomKey"),
                        KeyImage.transform.position + new Vector3(0f, 0f, -0.1f), Quaternion.identity);
                }
            }
        }
    }
}

