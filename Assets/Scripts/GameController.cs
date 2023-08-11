using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Appegy
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _toHitObjectPrefab;
        [SerializeField]
        private GameObject _throwObjectPrefab;

        private void Awake()
        {
            var cap = Instantiate(_toHitObjectPrefab,transform.GetChild(0));
            var arrow = Instantiate(_throwObjectPrefab,transform.GetChild(1));
        }
    }
}
