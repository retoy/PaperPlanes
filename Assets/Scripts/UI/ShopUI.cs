using UnityEngine;
using UnityEngine.UI;

public class ShopUI: MonoBehaviour
{
    [SerializeField] private Button homeButton;
    [SerializeField] private GameObject shopPredab;
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
        shopPredab.SetActive(false);
        GameObject menuPanel = Instantiate(menuPrefab, transform.parent);
    }
}
