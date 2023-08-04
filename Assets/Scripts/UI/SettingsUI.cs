using UnityEngine;
using UnityEngine.UI;
public class SettingsUI : MonoBehaviour
{
    [SerializeField] private Button homeButton;
    [SerializeField] private GameObject settingsPrefab;
    [SerializeField] private GameObject menuPrefab;

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
        settingsPrefab.SetActive(false);
        GameObject menuPanel = Instantiate(menuPrefab, transform.parent); 
        
    }
}
