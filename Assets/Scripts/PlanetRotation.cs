using UnityEngine;

namespace CroakGames
{
    public class PlanetRotation : MonoBehaviour
    {
        [SerializeField]
        private LevelConfig _level;

        private float _time;

        public LevelConfig Level
        {
            get => _level;
            set => _level = value;
        }

        private void Update()
        {
            _time += Time.deltaTime;
            var t = (2f * EasingFunc.InOutSinusoidal(_time) + Mathf.PI + 2f) * _level.Speed;
            transform.eulerAngles = new Vector3(0, 0, t);
        }
    }
}
