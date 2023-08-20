using System.Collections.Generic;
using UnityEngine;

namespace Appegy
{
    [CreateAssetMenu]
    public class PlaneConfig : ScriptableObject
    {
        [SerializeField]
        private List<Sprite> _planeList = new List<Sprite>();

        public List<Sprite> PlaneList => _planeList;
    }
}
