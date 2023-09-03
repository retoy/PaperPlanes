using UnityEngine;

namespace Appegy
{
    public class CapRotation : MonoBehaviour
    {
        [SerializeField]
        private LevelConfig _level;
        private float _time;
        
        private void Update()
        {
            _time += Time.deltaTime;
            var t = (2f * EasingFunc.InOutSinusoidal(_time) + Mathf.PI + 2f) * 200f;
            transform.eulerAngles = new Vector3(0, 0, t);
        }      
    }
}
