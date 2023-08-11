using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Appegy.UI.Menu
{
    public class MainMenuPanel : MonoBehaviour
    {
        [SerializeField]
        private Button _playButton;
        [SerializeField]
        private Button _settingsButton;
        [SerializeField]
        private Button _shopButton;
        [SerializeField]
        private TMP_Text _bestScore;

        public Button PlayButton => _playButton;
        public Button SettingsButton => _settingsButton;
        public Button ShopButton => _shopButton;

        private void OnEnable()
        {
            ShowBestScore();
        }

        private void ShowBestScore()
        {
            _bestScore.text = PlayerProgress.Instance.BestScore.ToString();
        }
    }
}