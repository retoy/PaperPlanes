using UnityEngine;

namespace Appegy
{
    public class CapRotation : MonoBehaviour
    {
        [SerializeField]
        private LevelConfig _level;

        private void Update()
        {
            var rotationAmount = _level.AnglePerSec * Time.deltaTime;
            switch(_level.Curve)
            {
                case LevelConfig.Function.Linear:
                    transform.Rotate(0, 0, rotationAmount);
                    break;

                case LevelConfig.Function.Linear2:
                    transform.Rotate(0, 0, rotationAmount + 10000);
                    break;
            }
        }
    }
}
