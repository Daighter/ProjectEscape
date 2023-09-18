using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bae
{
    public class JewelVFX : MonoBehaviour
    {
        [SerializeField]
        ParticleSystem particle;

        public void JewelVFXON()
        {
            particle.Play();
        }
    }
}

