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
        private float _speedAmplitude;
        [SerializeField]
        private float _speedFrequency;
        [SerializeField]
        private int _planesToWin;
        [SerializeField]
        private int _coinReward = 1;
        [SerializeField]
        private float[] _coinAngles;
        [SerializeField]
        private int _randomCoinsMin;
        [SerializeField]
        private int _randomCoinsMax;

        public Sprite Planet => _planet;
        public float Speed => _speed;
        public bool Clockwise => _clockwise;
        public float SpeedAmplitude => _speedAmplitude;
        public float SpeedFrequency => _speedFrequency;
        public int PlanesToWin => _planesToWin;
        public int CoinReward => _coinReward;
        public float[] CoinAngles => _coinAngles;
        public int RandomCoinsMin => _randomCoinsMin;
        public int RandomCoinsMax => _randomCoinsMax;
    }
}
