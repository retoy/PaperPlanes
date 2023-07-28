using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button shopButton;

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject shopPanel;

    private void OnEnable()
    {
        settingsButton.onClick.AddListener(OnSettingsButtonClick);
        shopButton.onClick.AddListener(OnShopButtonClick);
        playButton.onClick.AddListener(OnStartButtonClick);
    }
    private void OnDisable()
    {
        settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
        shopButton.onClick.RemoveListener(OnShopButtonClick);
        playButton.onClick.RemoveListener(OnStartButtonClick);
    }
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Game");
    }
    private void OnSettingsButtonClick()
    {
        settingsPanel.SetActive(true);
        shopPanel.SetActive(false);
        menuPanel.SetActive(false);
    }
    public void OnShopButtonClick()
    {
        shopPanel.SetActive(true);
        settingsPanel.SetActive(false);
        menuPanel.SetActive(false);
    }
}

