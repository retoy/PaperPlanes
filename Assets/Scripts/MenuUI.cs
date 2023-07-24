using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField]
    private Button[] levelButtons;

    public void Start()
    {
        OpenAvailableLevels();
    }

    private void OpenAvailableLevels()
    {
        for (int i = 0; i < LevelsProvider.Instance.LevelsCount; i++)
        {
            var button = levelButtons[i]; //TODO create button here
            var status = ProgressController.Instance.GetLevelStatus(i);

            switch (status)
            {
                case ProgressController.LevelStatus.NotAvailable:
                    button.interactable = false;
                    break;
                case ProgressController.LevelStatus.Available:
                case ProgressController.LevelStatus.Passed:
                    button.interactable = true;
                    break;
            }
        }
    }

    public void OnStartButtonClick(int level)
    {
        GameStatus.CurrentLevel = level;
        SceneManager.LoadScene("Game");
    }
}