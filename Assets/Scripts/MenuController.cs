using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CroakGames
{
    public class MenuController : MonoBehaviour
    {
        private void OnDestroy()
        {
            PlayerProgress.Instance.SaveProgress();
        }
    }
}
