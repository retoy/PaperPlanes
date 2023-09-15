using Cysharp.Threading.Tasks.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;

namespace CroakGames.UI.Menu
{
    public class ShopPanel : MonoBehaviour
    {
        [SerializeField]
        private Button _homeButton;
        [SerializeField]
        private PlaneConfig _planeConfig;
        [SerializeField]
        private ShopCell _cellPrefab;
        [SerializeField]
        private TMP_Text _coinsTotal;

        private List<ShopCell> _shopAssortment = new List<ShopCell>();
        private ShopCell _currentPlane;

        public Button HomeButton => _homeButton;

        private void Start()
        {
            PlayerProgress.Instance.OnPlaneChanged += SetCurrentPlane;
            PlayerProgress.Instance.OnCoinsValueChanged += ShowCoinsTotal;

            ShowShopAssortment();
            SetCurrentPlane();
            ShowCoinsTotal();
        }
        private void OnDestroy()
        {
            PlayerProgress.Instance.OnPlaneChanged -= SetCurrentPlane;
            PlayerProgress.Instance.OnCoinsValueChanged -= ShowCoinsTotal;

            foreach (var plane in transform.GetComponentInChildren<GridLayoutGroup>().GetComponentsInChildren<ShopCell>())
            {
                plane.Button.onClick.RemoveAllListeners();
            }

            PlayerProgress.Instance.SaveProgress();
        }

        private void ShowShopAssortment()
        {
            for (int index = 0; index < _planeConfig.PlaneList.Count; index++)
            {
                int currentIndex = index;

                var plane = Instantiate(_cellPrefab, transform.GetComponentInChildren<GridLayoutGroup>().transform);
                plane.PlaneImage.sprite = _planeConfig.PlaneList[index].Sprite;
                plane.Text.text = _planeConfig.PlaneList[index].Price.ToString();

                plane.Button.onClick.AddListener(() => onShopCellButtonClick(currentIndex));
                _shopAssortment.Add(plane);
            }
            _currentPlane = _shopAssortment[PlayerProgress.Instance.CurrentPlane];

            void onShopCellButtonClick(int newIndex)
            {
                //PlayerProgress.Instance.CurrentPlane = newIndex;
                PurchaseSkin(newIndex);
            }
        }

        private void SetCurrentPlane()
        {
            _currentPlane.FrameImage.color = Color.white;
            //_currentPlane.Text.text = "empty";
            _shopAssortment[PlayerProgress.Instance.CurrentPlane].FrameImage.color = Color.green;
            // shopAssortment[PlayerProgress.Instance.CurrentPlane].Text.text = "current";

            _currentPlane = _shopAssortment[PlayerProgress.Instance.CurrentPlane];
        }

        private void ShowCoinsTotal()
        {
            _coinsTotal.text = PlayerProgress.Instance.CoinsTotal.ToString();
        }

        void PurchaseSkin(int index)
        {
            if (_planeConfig.PlaneList[index].Price <= PlayerProgress.Instance.CoinsTotal)
            {
                PlayerProgress.Instance.CurrentPlane = index;
                PlayerProgress.Instance.CoinsTotal -= _planeConfig.PlaneList[index].Price;
            }
        }
    }
}
