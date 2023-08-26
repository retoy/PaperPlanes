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

        public Button HomeButton => _homeButton;

        private void OnEnable()
        {
            ShowShopAssortment();
        }
        private void OnDisable()
        {
            foreach(var plane in transform.GetComponentInChildren<GridLayoutGroup>().GetComponentsInChildren<ShopCell>())
            {
                plane.Button.onClick.RemoveAllListeners();
            }

            PlayerProgress.Instance.SaveProgress();
        }

        private void ShowShopAssortment()
        {
            List<ShopCell> shopAssortment = new List<ShopCell>();

            for(int index = 0; index < _planeConfig.PlaneList.Count; index++)
            {
                int currentIndex = index;

                var plane = Instantiate(_cellPrefab, transform.GetComponentInChildren<GridLayoutGroup>().transform);
                plane.PlaneImage.sprite = _planeConfig.PlaneList[index];

                plane.Button.onClick.AddListener(() => onShopCellButtonClick(currentIndex));
                shopAssortment.Add(plane);
            }

            showCurrentPlane(PlayerProgress.Instance.CurrentPlane);

            void onShopCellButtonClick(int newIndex)
            {
                shopAssortment[PlayerProgress.Instance.CurrentPlane].FrameImage.color = Color.white;
                shopAssortment[PlayerProgress.Instance.CurrentPlane].Text.text = "empty";

                PlayerProgress.Instance.CurrentPlane = newIndex;
                showCurrentPlane(newIndex);
            }

            void showCurrentPlane(int index)
            {
                shopAssortment[index].FrameImage.color = Color.green;
                shopAssortment[index].Text.text = "current";
            }
        }
        
    }
}