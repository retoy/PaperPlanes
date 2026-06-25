using UnityEngine;

namespace CroakGames
{
    public class PlanetRotation : MonoBehaviour
    {
        [SerializeField]
        private LevelConfig _level;

        public LevelConfig Level
        {
            get => _level;
            set => _level = value;
        }

        public float CurrentAngle => transform.eulerAngles.z;

        private void Update()
        {
            if (_level == null)
            {
                return;
            }

            var direction = _level.Clockwise ? -1f : 1f;
            transform.Rotate(0f, 0f, direction * _level.Speed * Time.deltaTime);
        }
    }
}
