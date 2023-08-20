using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Appegy.UI.Menu
{
    public class ShopPanel : MonoBehaviour
    {
        [SerializeField]
        private Button _homeButton;
        [SerializeField]
        private PlaneConfig _planeConfig;
        [SerializeField]
        private ShopCell _cellPrefab;

        public Button HomeButton => _homeButton;

        private void OnEnable()
        {
            ShowPlanes();
        }
        private void OnDisable()
        {
            foreach(var plane in transform.GetComponentInChildren<GridLayoutGroup>().GetComponentsInChildren<ShopCell>())
            {
                plane.Button.onClick.RemoveAllListeners();
            }
        }

        private void ShowPlanes()
        {
            foreach(var planeSprite in _planeConfig.PlaneList)
            {
                var plane = Instantiate(_cellPrefab, transform.GetComponentInChildren<GridLayoutGroup>().transform);
                plane.Image.sprite = planeSprite;
                plane.Button.onClick.AddListener(() => Debug.Log("CLICKED!")) ;
            }
        }
    }
}