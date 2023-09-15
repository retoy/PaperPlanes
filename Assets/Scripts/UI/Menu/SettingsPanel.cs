using Cysharp.Threading.Tasks.Triggers;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace CroakGames.UI.Menu
{
    public class SettingsPanel : MonoBehaviour
    {
        [SerializeField] private Button _homeButton;
        [SerializeField] private Sprite _audioOn;
        [SerializeField] private Sprite _audioOff;
        [SerializeField] private Button _buttonAudio;
        public Button HomeButton => _homeButton;

        private void Start()
        {
            PlayerProgress.Instance.OnMusicVolumeChanged += AudioButtonSpriteChange;
            AudioButtonSpriteChange();
            
        }

        private void OnDestroy()
        {
            PlayerProgress.Instance.OnMusicVolumeChanged -= AudioButtonSpriteChange; 
        }

        public void AudioButtonClick()
        {
            if (AudioListener.volume == 1)
            {
                AudioListener.volume = 0;
                PlayerProgress.Instance.MusicVolume = 0;
            }
            else
            {
                AudioListener.volume = 1;
                PlayerProgress.Instance.MusicVolume = 1;
            }
            PlayerProgress.Instance.SaveProgress();
            
        }

        public void AudioButtonSpriteChange()
        {
            if (AudioListener.volume == 0)
            {
                _buttonAudio.image.sprite = _audioOff;
            }
            else
            {
                _buttonAudio.image.sprite = _audioOn;
            }
            PlayerProgress.Instance.SaveProgress();
        }
    }
}
