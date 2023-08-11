using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Appegy
{
    public class GameProgress : MonoBehaviour
    {
        private int _currentScore;

        public int CurrentStage
        {
            get => _currentScore;
            set => _currentScore = value;
        }

        public void SaveProgress()
        {
            if(_currentScore > PlayerProgress.Instance.BestScore)
            {
                PlayerProgress.Instance.BestScore = _currentScore;
            }

            PlayerProgress.Instance.SaveProgress();
        }
    }
}
