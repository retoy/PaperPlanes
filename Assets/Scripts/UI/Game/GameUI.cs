using UnityEngine;
using UnityEngine.SceneManagement;

namespace Appegy.UI.Game
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _container;

        [SerializeField]
        private HudUI _hudPrefab;
        [SerializeField]
        private GameOverUI _gameOverUI;

        [SerializeField]
        private GameProgress _gameProgress;

        private void Awake()
        {
            ShowHudUI();
        }

        private void ShowHudUI()
        {
            var panel = Instantiate(_hudPrefab, _container);

            panel.LooseButton.onClick.AddListener(showLoosePanel);
            panel.SetGameProgress(_gameProgress);

            void release()
            {
                panel.LooseButton.onClick.RemoveListener(showLoosePanel);
                _gameProgress.SaveProgress();
                Destroy(panel.gameObject);
            }

            void showLoosePanel()
            {
                release();
                ShowLoosePanel();
            }
        }

        private void ShowLoosePanel()
        {
            var panel = Instantiate(_gameOverUI, _container);

            panel.HomeButton.onClick.AddListener(home);
            panel.RestartButton.onClick.AddListener(restart);

            void release()
            {
                panel.HomeButton.onClick.RemoveListener(home);
                panel.RestartButton.onClick.RemoveListener(restart);
                Destroy(panel.gameObject);
            }

            void home()
            {
                release();
                SceneManager.LoadScene("Menu");
            }

            void restart()
            {
                release();
                SceneManager.LoadScene("Game");
            }
        }
    }
}