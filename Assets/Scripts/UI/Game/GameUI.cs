using UnityEngine;
using UnityEngine.SceneManagement;

namespace CroakGames.UI.Game
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
        [SerializeField]
        private GameController _gameController;

        private HudUI _hud;

        private void Awake()
        {
            ShowHudUI();
        }

        private void OnEnable()
        {
            _gameController.GameOver += OnGameOver;
        }

        private void OnDisable()
        {
            _gameController.GameOver -= OnGameOver;
        }

        private void ShowHudUI()
        {
            _hud = Instantiate(_hudPrefab, _container);
            _hud.SetGameProgress(_gameProgress);
        }

        private void OnGameOver()
        {
            if (_hud != null)
            {
                Destroy(_hud.gameObject);
            }

            ShowLoosePanel();
        }

        private void ShowLoosePanel()
        {
            var panel = Instantiate(_gameOverUI, _container);

            panel.HomeButton.onClick.AddListener(Home);
            panel.RestartButton.onClick.AddListener(Restart);

            void Home()
            {
                SceneManager.LoadScene("Menu");
            }

            void Restart()
            {
                SceneManager.LoadScene("Game");
            }
        }
    }
}
