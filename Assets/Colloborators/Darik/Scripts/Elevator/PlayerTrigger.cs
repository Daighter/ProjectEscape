using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class PlayerTrigger : MonoBehaviour
    {
        [SerializeField] private LayerMask playerLayer;
        public string playerName;

        private GameObject player = null;

        public GameObject Player { get { return player;} }

        private void OnTriggerEnter(Collider other)
        {
            if (playerLayer.Contain(other.gameObject.layer))
                player = other.gameObject;
        }

        private void OnTriggerExit(Collider other)
        {
            if (playerLayer.Contain(other.gameObject.layer))
                player = null;
        }

        private void Update()
        {
            if (player != null)
                playerName = player.name;
            else
                playerName = "";
        }

        public void MoveInElevator(float moveSpeed)
        {
            player.transform.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
    }
}
