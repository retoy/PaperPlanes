using UnityEngine;
using UnityEngine.UI;

public class ShopUI: MonoBehaviour
{
    [SerializeField] private Button homeButton;
    [SerializeField] private GameObject shopPanel;
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
        shopPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}
