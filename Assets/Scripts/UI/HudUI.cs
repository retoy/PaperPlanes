using UnityEngine;
using UnityEngine.UI;

public class HudUI : MonoBehaviour
{
    [SerializeField] private Button looseButton;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private RectTransform canvas;

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
        Instantiate(gameOverPanel, canvas);
        this.gameObject.SetActive(false);
    }
}
