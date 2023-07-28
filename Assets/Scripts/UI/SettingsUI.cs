using UnityEngine;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Button homeButton;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject menuPanel;
    
    private void OnEnable()
    {
        homeButton.onClick.AddListener(OnHomeButtonClick);
    }
    private void OnDisable()
    {
        homeButton.onClick.RemoveListener(OnHomeButtonClick);
    }
    private void OnHomeButtonClick()
    {
        settingsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}
