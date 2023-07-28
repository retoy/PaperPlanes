using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{
    [SerializeField] 
    private Button settings;

    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject menuPanel;
    public void OnSettingsButtonClick()
    {
        settingsPanel.SetActive(true);
        menuPanel.SetActive(false);
    }
    public void Start()
    {
        settings.onClick.AddListener(OnSettingsButtonClick);
    }
}
