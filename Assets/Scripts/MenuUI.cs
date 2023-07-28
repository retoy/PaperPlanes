using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Button homeFromSettings;
    [SerializeField] private Button homeFromShop;
    [SerializeField] private Button play;

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject shopPanel;
    public void OnHomeFromSettingsButtonClick() 
    {
        settingsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
    public void OnHomeFromShopButtonClick()
    {
        shopPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
    public void Start()
    {
        homeFromSettings.onClick.AddListener(OnHomeFromSettingsButtonClick);
        homeFromShop.onClick.AddListener(OnHomeFromShopButtonClick);
    }
    public void changeScene(int sceneid)
    {
        SceneManager.LoadScene(sceneid);
    }
    
}

