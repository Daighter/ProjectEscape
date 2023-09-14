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
            if(other.transform.tag!= "Figure")//�ǱԾ �ƴѰ��� �� ��
            {
                other.transform.position = notBurn.position;
                return;
            }
            gameObject.GetComponent<AudioSource>().Play();
            other.gameObject.SetActive(false);
            figure.Add(other.gameObject.name);
            overStack++;

            if( overStack == count )
            {
                if(OfferCheck(figure))
                {
                    chest.GetComponent<Animator>().SetTrigger("Open");
                    chest.GetComponent<AudioSource>().Play();
                }
                else
                {
                    StartCoroutine(state.FigureRespawn());
                    figure.Clear();
                    overStack = 0;
                }
            }
           
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

