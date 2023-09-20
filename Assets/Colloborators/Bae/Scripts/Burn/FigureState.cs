using Darik;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bae
{
    public class FigureState : RandomParent
    {
        [SerializeField]
        GameObject[] figure;
        [SerializeField]
        GameObject[] figurePosition;
        List<Vector3> figurePositions;
        List<Quaternion> figureRotation;
        private void Awake()
        {
            figurePositions = new List<Vector3>();
            figureRotation = new List<Quaternion>();
            if (GameManager.Data.recipeDolls[0] != null)
            {
                return;
            }
            RandomOn(figure, GameManager.Data.recipeDolls);
        }

        private void OnEnable()
        {
            for(int i=0;i<figure.Length;i++)
            {
                figurePositions.Add(figurePosition[i].transform.position);
                figureRotation.Add(figurePosition[i].transform.rotation);
            }
        }


        public IEnumerator FigureRespawn()
        {
            yield return new WaitForSeconds(0.5f);
            for(int i=0;i<figurePositions.Count;i++) 
            {
                figurePosition[i].transform.position = figurePositions[i];
                figurePosition[i].transform.rotation = figureRotation[i];
                figurePosition[i].SetActive(true);
            }
            StopCoroutine(FigureRespawn());
        }
    }
}

