using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Bae
{
    public class BurnFigure : MonoBehaviour
    {
        [SerializeField] Transform notBurn;
        [SerializeField] GameObject chest;
        [SerializeField] int count;
        List<FigureState> figure;
        int offerStack=0;
        int overStack = 0;
        private void OnEnable()
        {
            figure = new List<FigureState>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.transform.tag!= "Figure")//피규어가 아닌것이 들어갈 때
            {
                other.transform.position = notBurn.position;
                return;
            }
            FigureState figureState=other.GetComponent<FigureState>();
            other.gameObject.SetActive(false);
            if(figureState.figureState!="Offer")//재물이 아닌것일 때
            {
                figure.Add(figureState);
                overStack++;
            }
            else
            {
                figure.Add(figureState);
                overStack++;
                offerStack++;
            }

            //제한수량이 다 들어갔을 경우
            if (overStack == count)
            {
                if (offerStack == count)
                {
                    chest.GetComponent<Animator>().SetTrigger("Open");
                }
                else
                {
                    overStack = 0;
                    offerStack = 0;
                    foreach(FigureState offerFigure in figure)
                    {
                        StartCoroutine(offerFigure.FigureRespawn());
                    }
                }
            }
        }
        
    }
}

