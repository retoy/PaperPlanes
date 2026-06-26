using System.Collections;
using UnityEngine;

namespace CroakGames
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField]
        private float _duration = 0.3f;
        [SerializeField]
        private float _magnitude = 0.25f;

        private Vector3 _origin;
        private Coroutine _routine;

        private void Awake()
        {
            _origin = transform.localPosition;
        }

        public void Shake()
        {
            if (!PlayerProgress.Instance.ShakeEnabled)
            {
                return;
            }

            if (_routine != null)
            {
                StopCoroutine(_routine);
            }

            _routine = StartCoroutine(ShakeRoutine());
        }

        private IEnumerator ShakeRoutine()
        {
            var elapsed = 0f;

            while (elapsed < _duration)
            {
                elapsed += Time.deltaTime;
                var damper = 1f - Mathf.Clamp01(elapsed / _duration);
                var offset = (Vector3)(Random.insideUnitCircle * (_magnitude * damper));
                transform.localPosition = _origin + offset;
                yield return null;
            }

            transform.localPosition = _origin;
            _routine = null;
        }
    }
}
