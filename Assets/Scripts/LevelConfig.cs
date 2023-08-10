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
        private int knifesToWin;

        public Sprite GetPrivateSprite()
        {
            return sprite;
        }
        public Curve GetPrivateCurve() 
        { 
            return curve; 
        }
        public float GetPrivateAnglePerSec()
        { 
            return anglePerSec; 
        }
        public int GetPrivateKnifesToWin() 
        {  
            return knifesToWin; 
        }
    }
}