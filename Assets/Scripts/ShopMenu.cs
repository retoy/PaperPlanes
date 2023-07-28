using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] private Button shop;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject menuPanel;
    public void OnShopButtonClick()
    {
        shopPanel.SetActive(true);
        menuPanel.SetActive(false);
    }
    public void Start()
    {
        shop.onClick.AddListener(OnShopButtonClick);
    }
}
