using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Appegy
{
    public class PlayerProgress : Singleton<PlayerProgress>
    {
        public int CoinsTotal
        {
            get => PlayerPrefs.GetInt("Coins");
            set => PlayerPrefs.SetInt("Coins", value);
        }
        public int BestScore
        {
            get => PlayerPrefs.GetInt("Score");
            set => PlayerPrefs.SetInt("Score", value);
        }

        public void SaveProgress()
        {
            PlayerPrefs.Save();
        }
    }
}
