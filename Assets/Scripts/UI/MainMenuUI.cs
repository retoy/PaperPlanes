using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//удаление копий  
public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button shopButton;

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject settingsPrefab;
    [SerializeField] private GameObject shopPrefab;

    private GameObject settingsPanel;
    private GameObject shopPanel;

    private void OnEnable()
    {
        settingsButton.onClick.AddListener(OnSettingsButtonClick);
        shopButton.onClick.AddListener(OnShopButtonClick);
        playButton.onClick.AddListener(OnPlayButtonClick);
    }

    private void OnDisable()
    {
        settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
        shopButton.onClick.RemoveListener(OnShopButtonClick);
        playButton.onClick.RemoveListener(OnPlayButtonClick);
    }

    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene("Game");
    }

    private void OnSettingsButtonClick()
    {
        if (settingsPanel == null)
        {
            settingsPanel = Instantiate(settingsPrefab, transform.parent);
            settingsPanel.SetActive(true);
            menuPanel.SetActive(false);
        }
        else
        {
            settingsPanel.SetActive(true);
            menuPanel.SetActive(false);
        }
    }

    private void OnShopButtonClick()
    {
        if (shopPanel == null)
        {
            shopPanel = Instantiate(shopPrefab, transform.parent);
            shopPanel.SetActive(true);
            menuPanel.SetActive(false);
        }
        else
        {
            shopPanel.SetActive(true);
            menuPanel.SetActive(false);
        }
    }
}