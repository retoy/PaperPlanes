using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopUI: MonoBehaviour
{
    [SerializeField] private Button home;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject menuPanel;
    
    private void OnEnable()
    {
        home.onClick.AddListener(OnHomeButtonClick);
    }
    private void OnDisable()
    {
        home.onClick.RemoveListener(OnHomeButtonClick);
    }
    private void OnHomeButtonClick()
    {
        shopPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}
