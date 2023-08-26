using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Appegy
{
    public class MenuController : MonoBehaviour
    {
        private void OnDestroy()
        {
            PlayerProgress.Instance.SaveProgress();
        }
    }
}
