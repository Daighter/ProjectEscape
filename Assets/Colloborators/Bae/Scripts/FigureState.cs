using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bae
{
    public class FigureState : MonoBehaviour
    {
        [SerializeField] public string figureState;
        Vector3 position;

        private void OnEnable()
        {
            position = transform.position;
        }
        public IEnumerator FigureRespawn()
        {
            yield return new WaitForSeconds(0.5f);
            transform.position = position;
            gameObject.SetActive(true);
            StopCoroutine(FigureRespawn());
        }
    }
}

