using Darik;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bae
{
    public class FigureState : MonoBehaviour
    {
        [SerializeField]
        GameObject[] figure;
        List<Vector3> figurePositions;
        List<Quaternion> figureRotation;
        private void Awake()
        {
            figurePositions = new List<Vector3>();
            figureRotation = new List<Quaternion>();
            if (GameManager.Data.recipeDolls[0] !=null)
            {
                return;
            }
            int dollIndex=0;
            while(dollIndex<3)
            {
                bool sameName = true;
                string figureName = figure[Random.Range(0, figure.Length)].name;
                for(int i=0;i<GameManager.Data.recipeDolls.Length;i++)
                {
                    if(GameManager.Data.recipeDolls[i]==figureName)
                    {
                        sameName = false;
                        break;
                    }
                }
                if(sameName)
                {
                    GameManager.Data.recipeDolls[dollIndex++]=figureName;
                }
                else
                {
                    continue;
                }
            }

        }

        private void OnEnable()
        {
            for(int i=0;i<figure.Length;i++)
            {
                figurePositions.Add(figure[i].transform.position);
                figureRotation.Add(figure[i].transform.rotation);
            }
        }


        public IEnumerator FigureRespawn()
        {
            yield return new WaitForSeconds(0.5f);
            for(int i=0;i<figurePositions.Count;i++) 
            {
                figure[i].transform.position = figurePositions[i];
                figure[i].transform.rotation = figureRotation[i];
                figure[i].SetActive(true);
            }
            StopCoroutine(FigureRespawn());
        }
    }
}

