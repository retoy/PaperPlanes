using UnityEngine;

namespace Appegy
{
    [CreateAssetMenu]
    public class LevelConfig : ScriptableObject
    {
        public enum Function
        {
            Linear,
            Linear2
        }
        [SerializeField]
        private Sprite _cap;
        [SerializeField]
        private Function _curve;
        [SerializeField]
        private float _anglePerSec;
        [SerializeField]
        private int _knivesToWin;

        public float AnglePerSec => _anglePerSec;
        public Function Curve => _curve;
        public float KnivesToWin => _knivesToWin;
        public Sprite Cap => _cap;

    }
}