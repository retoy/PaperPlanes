using UnityEngine;

namespace Appegy
{
    [CreateAssetMenu]
    public class LevelConfig : ScriptableObject
    {
        enum Curve
        {   
            Linear
        }
        [SerializeField]
        private Sprite sprite;
        [SerializeField]
        private Curve curve;
        [SerializeField]
        private float anglePerSec;
        [SerializeField]
        private int knifesToWin;
    }
}