using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UIElements;

namespace Bae
{
    public class BurnFigure : MonoBehaviour
    {
        [SerializeField] Transform notBurn;
        [SerializeField] GameObject chest;
        [SerializeField] FigureState state;
        int count=3;
        List<string> figure;
        int overStack = 0;
        private void OnEnable()
        {
            figure = new List<string>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.transform.tag!= "Figure")//피규어가 아닌것이 들어갈 때
            {
                other.transform.position = notBurn.position;
                return;
            }
            GameManager.Sound.PlayDungeonSound("Burn");
            other.gameObject.SetActive(false);
            figure.Add(other.gameObject.name);
            overStack++;

            if( overStack == count )
            {
                if(OfferCheck(figure))
                {
                    StartCoroutine(ChestOpenRoutine());
                }
                else
                {
                    StartCoroutine(state.FigureRespawn());
                    figure.Clear();
                    overStack = 0;
                }
            }
           
        }

        IEnumerator ChestOpenRoutine()
        {
            yield return new WaitForSeconds(2f);
            chest.GetComponent<Animator>().SetTrigger("Open");
            GameManager.Sound.PlayDungeonSound("ChestOpen");
        }
        private bool OfferCheck(List<string> figure)
        {
            for (int i = 0; i < count; i++)
            {
                if (figure[i] != GameManager.Data.recipeDolls[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}

