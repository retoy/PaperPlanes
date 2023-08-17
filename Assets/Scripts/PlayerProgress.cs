using System;
using UnityEngine;

namespace Appegy
{
    public class PlayerProgress : Singleton<PlayerProgress>
    {
        public event Action OnCoinsValueChanged;
        public event Action OnBestScoreChanged;

        public int CoinsTotal
        {
            get => PlayerPrefs.GetInt("Coins");
            set
            {
                PlayerPrefs.SetInt("Coins", value);
                OnCoinsValueChanged?.Invoke();
            }
        }

        public int BestScore
        {
            get => PlayerPrefs.GetInt("Score");
            set
            {
                PlayerPrefs.SetInt("Score", value);
                OnBestScoreChanged?.Invoke();
            }
        }
        public int PlaneValue
        {
            get => PlayerPrefs.GetInt("Plane");
            set => PlayerPrefs.SetInt("Plane", value);
        }

        public void SaveProgress()
        {
            PlayerPrefs.Save();
        }
    }
}
