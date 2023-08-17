using System.Collections.Generic;
using UnityEngine;

namespace Appegy
{
    [CreateAssetMenu]
    public class PlaneConfig : ScriptableObject
    {
        [SerializeField]
        List<Sprite> Plane = new List <Sprite> ();
        
    }
}
