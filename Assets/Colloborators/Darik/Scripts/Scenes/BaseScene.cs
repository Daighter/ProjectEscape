using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public abstract class BaseScene : MonoBehaviour
    {
        public float progress { get; protected set; }
        protected abstract IEnumerator LoadingCoroutine();

        protected void Awake()
        {
            GameManager.ObjM.SaveObj();
        }

        public void LoadAsync()
        {
            StartCoroutine(LoadingCoroutine());
        }
    }
}
