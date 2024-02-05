using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

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

            ShowAssortment();
            SetCurrentPlane();
            ShowCoinsTotal();
        }

        private void OnDestroy()
        {
            PlayerProgress.Instance.OnPlaneChanged -= SetCurrentPlane;
            PlayerProgress.Instance.OnCoinsValueChanged -= ShowCoinsTotal;
            foreach(var plane in transform.GetComponentInChildren<GridLayoutGroup>().GetComponentsInChildren<ShopCell>())
            {
                plane.Button.onClick.RemoveAllListeners();
            }

            PlayerProgress.Instance.SaveProgress();
        }

        private void SetCurrentPlane()
        {
            _currentPlane.IsOpen = true;
            _shopAssortment[PlayerProgress.Instance.CurrentPlaneId].SetCurrent();
            _currentPlane = _shopAssortment[PlayerProgress.Instance.CurrentPlaneId];
        }

        private void ShowAssortment()
        {
            List<string> openSkins = new List<string>();
            openSkins.AddRange(PlayerProgress.Instance.OpenPlanesId.Split(','));

            for(int index = 0; index < _planeConfig.PlaneList.Count; index++)
            {
                int currentIndex = index;

                var plane = Instantiate(_cellPrefab, transform.GetComponentInChildren<GridLayoutGroup>().transform);

                plane.Plane = _planeConfig.PlaneList[index];
                plane.IsOpen = openSkins.Contains(index.ToString());
                if(!plane.IsOpen && plane.Plane.PaymentType == Currency.Ad && PlayerProgress.Instance.GetAdPlane(currentIndex) == 0)
                {
                    PlayerProgress.Instance.SetAdPlane(currentIndex, plane.Plane.Price);
                }

                plane.Button.onClick.AddListener(() => onShopCellButtonClick(currentIndex));

                _shopAssortment.Add(plane);
            }

            _currentPlane = _shopAssortment[PlayerProgress.Instance.CurrentPlaneId];

            void onShopCellButtonClick(int index)
            {
                var cell = _shopAssortment[index];
                if(cell.IsOpen)
                {
                    PlayerProgress.Instance.CurrentPlaneId = index;
                }
                else
                {
                    switch(_shopAssortment[index].Plane.PaymentType)
                    {
                        case Currency.Ad:
                            var temp = PlayerProgress.Instance.GetAdPlane(index) - 1;
                            if(temp <= 0)
                            {
                                cell.IsOpen = true;
                                PlayerProgress.Instance.OpenPlanesId = cell.Plane.Id.ToString();
                            }
                            else
                            {
                                PlayerProgress.Instance.SetAdPlane(index, temp);
                                cell.IsOpen = false;
                            }
                            break;

                        case Currency.Coin:
                            if(cell.Plane.Price <= PlayerProgress.Instance.CoinsTotal)
                            {
                                cell.IsOpen = true;
                                PlayerProgress.Instance.CoinsTotal -= cell.Plane.Price;
                                PlayerProgress.Instance.OpenPlanesId = cell.Plane.Id.ToString();
                            }
                            break;
                    }
                }
            }
        }

        private void ShowCoinsTotal()
        {
            _coinsTotal.text = PlayerProgress.Instance.CoinsTotal.ToString();
        }
    }
}
