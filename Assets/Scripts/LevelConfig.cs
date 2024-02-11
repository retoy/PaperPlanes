using UnityEngine;

namespace CroakGames
{
    [CreateAssetMenu]
    public class LevelConfig : ScriptableObject
    {
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