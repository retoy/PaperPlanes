using UnityEngine;

namespace CroakGames
{
    public class PlanetRotation : MonoBehaviour
    {
        [SerializeField]
        private LevelConfig _level;

        private float _elapsed;

        public LevelConfig Level
        {
            get => _level;
            set
            {
                _level = value;
                _elapsed = 0f;
            }
        }

        public float CurrentAngle => transform.eulerAngles.z;

        private void Update()
        {
            if (_level == null)
            {
                return;
            }

            _elapsed += Time.deltaTime;

            var direction = _level.Clockwise ? -1f : 1f;
            var modulation = 1f + _level.SpeedAmplitude *
                Mathf.Sin(2f * Mathf.PI * _level.SpeedFrequency * _elapsed);

            transform.Rotate(0f, 0f, direction * _level.Speed * modulation * Time.deltaTime);
        }
    }
}
