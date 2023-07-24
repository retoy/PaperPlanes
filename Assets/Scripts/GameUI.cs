using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject hud;
    [SerializeField]
    private GameObject losePanel;
    [SerializeField]
    private GameObject victoryPanel;

    private void Awake()
    {
        hud.SetActive(true);
        victoryPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    public void OnLoseButtonClick()
    {
        hud.SetActive(false);
        victoryPanel.SetActive(false);
        losePanel.SetActive(true);
    }

    public void OnWinButtonClick(int starsAmount)
    {
        ProgressController.Instance.MarkLevelPassed(GameStatus.CurrentLevel, starsAmount);
        hud.SetActive(false);
        victoryPanel.SetActive(true);
        losePanel.SetActive(false);
    }

    public void OnHomeButtonClick()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnNextButtonClick()
    {
        if (GameStatus.CurrentLevel < LevelsProvider.Instance.LevelsCount - 1)
        {
            GameStatus.CurrentLevel++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }
}