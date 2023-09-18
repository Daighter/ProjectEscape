using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public abstract class BaseScene : MonoBehaviour
    {
        public float progress { get; protected set; }

        public int SceneNum { get; protected set; }

        protected abstract IEnumerator LoadingCoroutine();

        public void LoadAsync()
        {
            StartCoroutine(LoadingCoroutine());
        }
    }
}
