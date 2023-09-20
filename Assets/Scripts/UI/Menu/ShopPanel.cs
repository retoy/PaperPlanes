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
        [SerializeField]
        private Button _watchAdButton;
        [SerializeField]
        private TMP_Text _adTotal;

        private List<ShopCell> _shopAssortment = new List<ShopCell>();
        private ShopCell _currentPlane;

        public Button HomeButton => _homeButton;

        private void Start()
        {
            _watchAdButton.onClick.AddListener(OnWatchAdButtonClick);
            PlayerProgress.Instance.OnPlaneChanged += SetCurrentPlane;
            PlayerProgress.Instance.OnCoinsValueChanged += ShowCoinsTotal;
            PlayerProgress.Instance.OnAdValueChanged += ShowAdTotal;
            ShowShopAssortment();
            SetCurrentPlane();
            ShowCoinsTotal();
            ShowAdTotal();
        }

        //private void Update()
        //{
        //    ShowAdTotal();
        //}
        private void OnDestroy()
        {
            _watchAdButton.onClick.RemoveListener(OnWatchAdButtonClick);
            PlayerProgress.Instance.OnPlaneChanged -= SetCurrentPlane;
            PlayerProgress.Instance.OnCoinsValueChanged -= ShowCoinsTotal;
            PlayerProgress.Instance.OnAdValueChanged -= ShowAdTotal;
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
                if (_planeConfig.PlaneList[newIndex].PaymentType == (int)Currency.ad)
                {
                    PurchaseAdSkin(newIndex);
                }
                else
                {
                    PurchaseSkin(newIndex);
                }
                //PlayerProgress.Instance.CurrentPlane = newIndex;
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

        void PurchaseAdSkin(int index)
        {
            if (_planeConfig.PlaneList[index].Price <= PlayerProgress.Instance.AdTotal)
            {
                PlayerProgress.Instance.CurrentPlane = index;
                PlayerProgress.Instance.AdTotal -= _planeConfig.PlaneList[index].Price;
            }
        }
        private void OnWatchAdButtonClick()
        {
            PlayerProgress.Instance.AdTotal++;
        }

        private void ShowAdTotal()
        {
            _adTotal.text = PlayerProgress.Instance.AdTotal.ToString();
        }
    }
}
