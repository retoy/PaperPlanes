using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Appegy
{
    public class GameProgress : MonoBehaviour
    {
        private int _currentStage;

        public int CurrentStage
        {
            get => _currentStage;
            set => _currentStage = value;
        }

        public void SaveProgress()
        {
            if(_currentStage > PlayerProgress.Instance.BestScore)
            {
                PlayerProgress.Instance.BestScore = _currentStage;
            }

            PlayerProgress.Instance.SaveProgress();
        }
    }
}
