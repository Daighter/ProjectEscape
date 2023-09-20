using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class ResourceManager : MonoBehaviour
    {
        Dictionary<string, Object> resources = new Dictionary<string, Object>();
        public T Load<T>(string path) where T : Object
        {
            string key = $"{typeof(T)}.{path}";

            if (resources.ContainsKey(key))
                return resources[key] as T;

            T resource = Resources.Load<T>(path);
            resources.Add(key, resource);
            return resource;
        }

        public T Instantiate<T>(T original, Vector3 position, Quaternion rotation, Transform parent, bool pooling = false) where T : Object
        {
            if (pooling)
            {
                //Debug.Log($"{original.name} Getted");
                return GameManager.Pool.Get(original, position, rotation, parent);
            }
            else
            {
                //Debug.Log("Instantiated");
                return Object.Instantiate(original, position, rotation, parent);
            }
        }

        public T Instantiate<T>(T original, Vector3 position, Quaternion rotation, bool pooling = false) where T : Object
        {
            return Instantiate<T>(original, position, rotation, null, pooling);
        }

        public new T Instantiate<T>(T original, Transform parent, bool pooling = false) where T : Object
        {
            return Instantiate<T>(original, Vector3.zero, Quaternion.identity, parent, pooling);
        }

        public T Instantiate<T>(T original, bool pooling = false) where T : Object
        {
            return Instantiate<T>(original, Vector3.zero, Quaternion.identity, null, pooling);
        }

        public T Instantiate<T>(string path, Vector3 position, Quaternion rotation, Transform parent, bool pooling = false) where T : Object
        {
            T original = Load<T>(path);
            return Instantiate<T>(original, position, rotation, parent, pooling);
        }

        public T Instantiate<T>(string path, Vector3 position, Quaternion rotation, bool pooling = false) where T : Object
        {
            return Instantiate<T>(path, position, rotation, null, pooling);
        }

        public T Instantiate<T>(string path, Transform parent, bool pooling = false) where T : Object
        {
            return Instantiate<T>(path, Vector3.zero, Quaternion.identity, parent, pooling);
        }

        public T Instantiate<T>(string path, bool pooling = false) where T : Object
        {
            return Instantiate<T>(path, Vector3.zero, Quaternion.identity, null, pooling);
        }

        public void Destroy(GameObject go)
        {
            if (GameManager.Pool.IsContain(go))
            {
                //Debug.Log($"{go.name} Released");
                GameManager.Pool.Release(go);
            }
            else
            {
                //Debug.Log($"{go.name} Destroyed");
                GameObject.Destroy(go);
            }
        }

        public void Destroy(GameObject go, float delay)
        {
            if (GameManager.Pool.IsContain(go))
                StartCoroutine(DelayReleaseRoutine(go, delay));
            else
                GameObject.Destroy(go, delay);
        }

        IEnumerator DelayReleaseRoutine(GameObject go, float delay)
        {
            yield return new WaitForSeconds(delay);
            GameManager.Pool.Release(go);
        }

        public void Destroy(Component component, float delay = 0f)
        {
            Component.Destroy(component, delay);
        }
    }
}
