using UnityEngine;
using UnityEngine.UI;

namespace CroakGames.UI.Menu
{
    public class SettingsPanel : MonoBehaviour
    {
        [SerializeField] private Button _homeButton;
        [SerializeField] private Button _musicButton;
        [SerializeField] private Button _sfxButton;
        [SerializeField] private Button _shakeButton;
        [SerializeField] private Sprite _onSprite;
        [SerializeField] private Sprite _offSprite;

        public Button HomeButton => _homeButton;

        private void Start()
        {
            _musicButton.onClick.AddListener(ToggleMusic);
            _sfxButton.onClick.AddListener(ToggleSfx);
            _shakeButton.onClick.AddListener(ToggleShake);

            RefreshSprites();
        }

        private void OnDestroy()
        {
            _musicButton.onClick.RemoveListener(ToggleMusic);
            _sfxButton.onClick.RemoveListener(ToggleSfx);
            _shakeButton.onClick.RemoveListener(ToggleShake);
        }

        private void ToggleMusic()
        {
            PlayerProgress.Instance.MusicVolume = PlayerProgress.Instance.MusicVolume > 0f ? 0f : 1f;
            PlayerProgress.Instance.SaveProgress();
            RefreshSprites();
        }

        private void ToggleSfx()
        {
            PlayerProgress.Instance.SfxEnabled = !PlayerProgress.Instance.SfxEnabled;
            PlayerProgress.Instance.SaveProgress();
            RefreshSprites();
        }

        private void ToggleShake()
        {
            PlayerProgress.Instance.ShakeEnabled = !PlayerProgress.Instance.ShakeEnabled;
            PlayerProgress.Instance.SaveProgress();
            RefreshSprites();
        }

        private void RefreshSprites()
        {
            _musicButton.image.sprite = PlayerProgress.Instance.MusicVolume > 0f ? _onSprite : _offSprite;
            _sfxButton.image.sprite = PlayerProgress.Instance.SfxEnabled ? _onSprite : _offSprite;
            _shakeButton.image.sprite = PlayerProgress.Instance.ShakeEnabled ? _onSprite : _offSprite;
        }
    }
}
