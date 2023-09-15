using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CroakGames.UI.Game
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private Button _homeButton;
        [SerializeField] private Button _restartButton;

        public Button HomeButton => _homeButton;
        public Button RestartButton => _restartButton;
    }
}
