using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class TrueEnd : MonoBehaviour
    {
       [SerializeField] private PlayerTrigger playerTrigger1F;
       
       private void Start()
       {
           StartCoroutine(TrueEndingCheckCoroutine());
       }
       
       IEnumerator TrueEndingCheckCoroutine()
       {
           while (true)
           {
               if (playerTrigger1F.Player != null)
               {
                   playerTrigger1F.Player.GetComponentInChildren<Bae.TrueEnd>().TrueEnding(3);
                   yield break;
               }
       
               yield return new WaitForSeconds(0.2f);
           }
       }
    }
}
