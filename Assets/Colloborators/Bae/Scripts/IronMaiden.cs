using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bae
{
    public class IronMaiden : MonoBehaviour
    {
        [SerializeField] GameObject skeleton;
        Animator ani;
        GameObject offer;
        private void Awake()
        {
            ani = GetComponent<Animator>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.transform.tag != "Figure")
            {
                return;
            }

            FigureState figureState = other.GetComponent<FigureState>();
            if(figureState.figureState == "IronOffer")
            {
                offer = other.gameObject;
            }
            else
            {
                return;
            }
        }
        public void IronMaidenClose()
        {
            StartCoroutine(CloseRoutine());
        }
        public void IronMaidenOpen()
        {
            ani.SetBool("IronState", true);
        }

        IEnumerator CloseRoutine()
        {
            ani.SetBool("IronState", false);
            yield return new WaitForSeconds(0.5f);
            if (offer != null)
            {
                offer.SetActive(false);
                skeleton.SetActive(true);
            }
        }
    }
}

