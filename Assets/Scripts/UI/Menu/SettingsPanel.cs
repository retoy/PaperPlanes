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
        private Sprite _audioOFF;
        [SerializeField]
        private GameObject _buttonAudio;
        private Image _image;
        public Button HomeButton => _homeButton;

        private void Start()
        {
            _image = GetComponent<Image>();
        }

        public void OnOffAudioButtonClick()
        {
            if (AudioListener.volume == 1)
            {
                AudioListener.volume = 0;
                _image.sprite = _audioOFF;
            }
            else
            {
                AudioListener.volume = 1;
                _image.sprite = _audioOn;
            }
        }
    }
}
