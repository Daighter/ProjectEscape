using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Darik
{
    public class PrisonRoomScene : BaseScene
    {
        protected override IEnumerator LoadingCoroutine()
        {
            progress = 0.0f;
            yield return null;
            progress = 1.0f;
        }
    }
}
