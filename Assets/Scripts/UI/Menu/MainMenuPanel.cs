using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Appegy.UI.Menu
{
    public class MainMenuPanel : MonoBehaviour
    {
        [FormerlySerializedAs("playButton")]
        [SerializeField]
        private Button _playButton;
        [FormerlySerializedAs("settingsButton")]
        [SerializeField]
        private Button _settingsButton;
        [FormerlySerializedAs("shopButton")]
        [SerializeField]
        private Button _shopButton;
        [SerializeField]
        private TMP_Text bestScore;

        public Button PlayButton => _playButton;

        public Button SettingsButton => _settingsButton;

        public Button ShopButton => _shopButton;

        private void OnEnable()
        {
            ShowBestScore();
        }

        private void ShowBestScore()
        {
            bestScore.text = PlayerProgress.Instance.BestScore.ToString();
        }
    }
}