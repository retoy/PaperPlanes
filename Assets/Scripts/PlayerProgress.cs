using System;
using UnityEngine;

namespace CroakGames
{
    public class PlayerProgress : Singleton<PlayerProgress>
    {
        public event Action OnCoinsValueChanged;
        public event Action OnBestScoreChanged;
        public event Action OnPlaneChanged;
        public event Action OnMusicVolumeChanged;
        public event Action OnAdValueChanged;
        public event Action OnSkinLockChanged;
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

        public int CurrentPlane
        {
            get => PlayerPrefs.GetInt("Plane");
            set
            {
                PlayerPrefs.SetInt("Plane", value);
                OnPlaneChanged?.Invoke();
            }
        }
        public float MusicVolume
        {
            get => PlayerPrefs.GetFloat("Volume");
            set
            {
                {
                    PlayerPrefs.SetFloat("Volume", value);
                    OnMusicVolumeChanged?.Invoke();
                }
            }
        }
        public int BoughtSkins
        {
            get => PlayerPrefs.GetInt("SkinId");
            set
            {
                PlayerPrefs.SetInt("SkinId", value);
            }
        }

        public int AdTotal
        {
            get => PlayerPrefs.GetInt("Ad");
            set
            {
                PlayerPrefs.SetInt("Ad", value);
                OnAdValueChanged?.Invoke();
            }
        }

        public int SkinLock
        {
            get => PlayerPrefs.GetInt("SkinUnlocked_");
            set
            {
                PlayerPrefs.SetInt("SkinUnlocked_", value);
                OnSkinLockChanged?.Invoke();
            }
        }

        public void SaveProgress()
        {
            PlayerPrefs.Save();
        }
    }
}