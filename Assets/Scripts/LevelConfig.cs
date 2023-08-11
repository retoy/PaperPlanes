using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace Appegy
{
    [CreateAssetMenu]
    public class LevelConfig : ScriptableObject
    {
        public enum Curve
        {   
            Linear,
            Linear2
        }
        [SerializeField]
        private Sprite sprite;
        [SerializeField]
        private Curve curve;
        [SerializeField]
        private float anglePerSec;
        [SerializeField]
        private int knivesToWin;

        public float GetAnglePerSec => anglePerSec;
        public Curve GetCurve => curve;
        public float GetKnivesToWin => knivesToWin;
        public Sprite GetSprite => sprite;

    }
}