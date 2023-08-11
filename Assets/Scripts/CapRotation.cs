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
            float rotationAmount = Level.GetAnglePerSec * Time.deltaTime;
            switch (Level.GetCurve)
            {
                case LevelConfig.Curve.Linear:
                    transform.Rotate(0, 0, rotationAmount);
                break;

                case LevelConfig.Curve.Linear2:
                    transform.Rotate(0, 0, rotationAmount + 10000);
                break;  
            }                        
        }
    }
}
