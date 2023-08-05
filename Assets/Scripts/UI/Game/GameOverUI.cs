using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Appegy.UI.Game
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private Button homeButton;
        [SerializeField] private Button restartButton;

        private void OnEnable()
        {
            homeButton.onClick.AddListener(OnHomeButtonClick);
            restartButton.onClick.AddListener(OnRestartButtonClick);
        }
        private void OnDisable()
        {
            homeButton.onClick.RemoveListener(OnHomeButtonClick);
            restartButton.onClick.RemoveListener(OnRestartButtonClick);
        }

        private void OnHomeButtonClick()
        {
            SceneManager.LoadScene("Menu");
        }
        private void OnRestartButtonClick()
        {
            SceneManager.LoadScene("Game");
        }
    }
}
