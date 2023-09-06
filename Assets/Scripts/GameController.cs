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
        [SerializeField]
        private GameProgress _gameProgress;
        [SerializeField]
        private PlaneConfig _planeConfig;

        private void Awake()
        {
            var cap = Instantiate(_toHitObjectPrefab,transform.GetChild(0));

            var arrow = Instantiate(_throwObjectPrefab,transform.GetChild(1));
            arrow.GetComponent<SpriteRenderer>().sprite = _planeConfig.planeList[PlayerProgress.Instance.CurrentPlane].Sprite;
        }

        private void OnDestroy()
        {
            _gameProgress.SaveProgress();
        }
    }
}
