using UnityEngine;

namespace CroakGames
{
    [CreateAssetMenu]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField]
        private Sprite _planet;
        [SerializeField]
        private float _speed;
        [SerializeField]
        private bool _clockwise;
        [SerializeField]
        private int _planesToWin;
        [SerializeField]
        private int _coinReward = 1;

        public Sprite Planet => _planet;
        public float Speed => _speed;
        public bool Clockwise => _clockwise;
        public int PlanesToWin => _planesToWin;
        public int CoinReward => _coinReward;
    }
}
