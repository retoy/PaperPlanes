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

        public Button PlayButton => _playButton;

        public Button SettingsButton => _settingsButton;

        public Button ShopButton => _shopButton;
    }
}