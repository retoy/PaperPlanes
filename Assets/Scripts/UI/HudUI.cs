using UnityEngine;
using UnityEngine.UI;

public class HudUI : MonoBehaviour
{
    [SerializeField] private Button looseButton;

    [SerializeField] private GameObject gameOverPrefab;

    private GameObject gameOverPanel;

    private void OnEnable()
    {
        looseButton.onClick.AddListener(OnLooseButtonClick);
    }

    private void OnDisable()
    {
        looseButton.onClick.RemoveListener(OnLooseButtonClick);
    }

    private void OnLooseButtonClick()
    {
        gameOverPanel = Instantiate(gameOverPrefab, transform.parent);
        gameOverPanel.SetActive(true);
    }
}
