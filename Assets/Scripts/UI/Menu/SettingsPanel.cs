using Cysharp.Threading.Tasks.Triggers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Appegy.UI.Menu
{
    public class SettingsPanel : MonoBehaviour
    {
        [SerializeField]
        private Button _homeButton;
        [SerializeField]
        private Sprite _audioOn;
        [SerializeField]
        private Sprite _audioOff;
        [SerializeField]
        private Button _buttonAudio;
        private Image _image;
        public Button HomeButton => _homeButton;

        private void Start()
        {
            _image = GetComponent<Image>();
           if(AudioListener.volume == 0)
            {
                _buttonAudio.image.sprite = _audioOff;
            }
           else
            {
                _buttonAudio.image.sprite= _audioOn;
            }

        }

        public void OnOffAudioButtonClick()
        {
            if (AudioListener.volume == 1)
            {
                AudioListener.volume = 0;
                //_image.sprite = _audioOFF;
                _buttonAudio.image.sprite = _audioOff;
                PlayerPrefs.SetFloat("Music",AudioListener.volume);
                
            }
            else
            {
                AudioListener.volume = 1;
                //_image.sprite = _audioOn;
                _buttonAudio.image.sprite = _audioOn;
                PlayerPrefs.SetFloat("Music", AudioListener.volume);
            }
        }
    }
}
