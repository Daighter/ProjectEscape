using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bae
{
    public class OpenJail : MonoBehaviour
    {
        public void Open()
        {
            GameManager.Data.OpenChest();
        }
    }
}

