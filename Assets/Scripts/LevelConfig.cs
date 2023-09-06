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
        private float _speed;
        [SerializeField]
        private int _planesToWin;

        public float Speed => _speed;
        public Function Curve => _curve;
        public int PlanesToWin => _planesToWin;
        public Sprite Cap => _cap;

    }
}