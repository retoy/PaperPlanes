using UnityEngine;
using UnityEngine.SceneManagement;

namespace Appegy.UI.Menu
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _container;

        [SerializeField]
        private MainMenuPanel _menuPrefab;
        [SerializeField]
        private SettingsPanel _settingsPanel;
        [SerializeField]
        private ShopPanel _shopPanel;

        private void Awake()
        {
            ShowMainMenu();
        }

        private void ShowMainMenu()
        {
            var panel = Instantiate(_menuPrefab, _container);

            panel.PlayButton.onClick.AddListener(play);
            panel.SettingsButton.onClick.AddListener(openSettings);
            panel.ShopButton.onClick.AddListener(openShop);

            void release()
            {
                panel.PlayButton.onClick.RemoveListener(play);
                panel.SettingsButton.onClick.RemoveListener(openSettings);
                panel.ShopButton.onClick.RemoveListener(openShop);
                Destroy(panel.gameObject);
            }

            void play()
            {
                release();
                SceneManager.LoadScene("Game");
            }

            void openSettings()
            {
                release();
                ShowSettingsPanel();
            }

            void openShop()
            {
                release();
                ShowShopPanel();
            }
        }

        private void ShowSettingsPanel()
        {
            var panel = Instantiate(_settingsPanel, _container);
            panel.HomeButton.onClick.AddListener(home);

            void release()
            {
                panel.HomeButton.onClick.RemoveListener(home);
                Destroy(panel.gameObject);
            }

            void home()
            {
                release();
                ShowMainMenu();
            }
        }

        private void ShowShopPanel()
        {
            var panel = Instantiate(_shopPanel, _container);

            panel.HomeButton.onClick.AddListener(home);

            void release()
            {
                panel.HomeButton.onClick.RemoveListener(home);
                Destroy(panel.gameObject);
            }

            void home()
            {
                release();
                ShowMainMenu();
            }
        }
    }
}