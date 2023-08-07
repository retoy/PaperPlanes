using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Appegy
{
    public class GameProgress : MonoBehaviour
    {
        private int currentScore;
        private int coinsCollected;

        public int CurrentStage
        {
            get => currentScore;
            set => currentScore = value;
        }
        public int CoinsCollected
        {
            get => coinsCollected;
            set => coinsCollected = value;
        }
        public void SaveProgress()
        {
            if(coinsCollected != 0)
            {
                PlayerProgress.Instance.CoinsTotal += coinsCollected;
            }
            if (currentScore > PlayerProgress.Instance.BestScore)
            {
                PlayerProgress.Instance.BestScore = currentScore;
            }

            PlayerProgress.Instance.SaveProgress();
        }
        
    }
}
