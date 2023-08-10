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
                case LevelConfig.Curve.Linear:
                    float rotationAmount = Level.GetPrivateAnglePerSec() * Time.deltaTime;
                    transform.Rotate(0, 0, rotationAmount);
                break;

                case LevelConfig.Curve.Linear2:
                    rotationAmount = Level.GetPrivateAnglePerSec() * Time.deltaTime;
                    transform.Rotate(0, 0, rotationAmount + 10000);
                break;  
            }                        
        }
    }
}
