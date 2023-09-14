using UnityEngine;

namespace Jeong
{
    public class ObjectEffect : MonoBehaviour
    {
        [SerializeField] GameObject objEffect;

        private void Start()
        {
            objEffect.SetActive(true);
        }

        public void EffectOn()
        {
            objEffect.SetActive(true);
        }

        public void EffectOff()
        {
            objEffect.SetActive(false);
        }
    }

}
