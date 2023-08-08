using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Appegy
{
    public class CapRotation : MonoBehaviour
    {
        [SerializeField]
        private LevelConfig Level;

       
        
        private void Update()
        {
            switch (Level.GetPrivateCurve())
            {
                case 0:
                    float rotationAmount = Level.GetPrivateAnglePerSec() * Time.deltaTime;
                    transform.Rotate(0, 0, rotationAmount);
                break;
            }                        
        }
    }
}
