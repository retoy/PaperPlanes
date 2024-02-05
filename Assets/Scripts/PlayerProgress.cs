using System;
using System.Linq;
using UnityEngine;

namespace CroakGames
{
    public class PlayerProgress : Singleton<PlayerProgress>
    {
        public event Action OnCoinsValueChanged;
        public event Action OnBestScoreChanged;
        public event Action OnPlaneChanged;
        public event Action OnMusicVolumeChanged;

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
        public int CurrentPlaneId
        {
            get => PlayerPrefs.GetInt("Plane");
            set
            {
                PlayerPrefs.SetInt("Plane", value);
                OnPlaneChanged?.Invoke();
            }
        }
        public string OpenPlanesId
        {
            get => PlayerPrefs.GetString("OpenPlanes");
            set
            {
                var temp = PlayerPrefs.GetString("OpenPlanes");
                PlayerPrefs.SetString("OpenPlanes", temp + value + ',');
                SaveProgress();
            }
        }
        public float MusicVolume
        {
            get => PlayerPrefs.GetFloat("Volume");
            set
            {
                PlayerPrefs.SetFloat("Volume", value);
                OnMusicVolumeChanged?.Invoke();

            }
        }

        public int GetAdPlane(int index)
        {
            return PlayerPrefs.GetInt($"Plane_{index}", 0);
        }

        public void SetAdPlane(int index, int adValue)
        {
            PlayerPrefs.SetInt($"Plane_{index}", adValue);
        }

        public void SaveProgress()
        {
            PlayerPrefs.Save();
        }
    }
}