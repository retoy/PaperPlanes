using Cysharp.Threading.Tasks.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
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

        private List<ShopCell> shopAssortment = new List<ShopCell>();
        private ShopCell _currentPlane;

        public Button HomeButton => _homeButton;

        private void Start()
        {
            PlayerProgress.Instance.OnPlaneChanged += SetCurrentPlane;

            ShowShopAssortment();
            SetCurrentPlane();
        }
        private void OnDestroy()
        {
            PlayerProgress.Instance.OnPlaneChanged -= SetCurrentPlane;

            foreach(var plane in transform.GetComponentInChildren<GridLayoutGroup>().GetComponentsInChildren<ShopCell>())
            {
                plane.Button.onClick.RemoveAllListeners();
            }

            PlayerProgress.Instance.SaveProgress();
        }

        private void ShowShopAssortment()
        {
            for(int index = 0; index < _planeConfig.PlaneList.Count; index++)
            {
                int currentIndex = index;

                var plane = Instantiate(_cellPrefab, transform.GetComponentInChildren<GridLayoutGroup>().transform);
                plane.PlaneImage.sprite = _planeConfig.PlaneList[index];

                plane.Button.onClick.AddListener(() => onShopCellButtonClick(currentIndex));
                shopAssortment.Add(plane);
            }
            _currentPlane = shopAssortment[PlayerProgress.Instance.CurrentPlane];

            void onShopCellButtonClick(int newIndex)
            {
                PlayerProgress.Instance.CurrentPlane = newIndex;
            }
        }

        private void SetCurrentPlane()
        {
            _currentPlane.FrameImage.color = Color.white;
            _currentPlane.Text.text = "empty";

            shopAssortment[PlayerProgress.Instance.CurrentPlane].FrameImage.color = Color.green;
            shopAssortment[PlayerProgress.Instance.CurrentPlane].Text.text = "current";

            _currentPlane = shopAssortment[PlayerProgress.Instance.CurrentPlane];
        }
    }
}