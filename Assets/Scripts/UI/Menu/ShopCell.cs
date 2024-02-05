using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CroakGames
{
    public class ShopCell : MonoBehaviour
    {
        [SerializeField]
        private Plane _plane;
        [SerializeField]
        private Image _Icon;
        [SerializeField]
        private Image _frame;
        [SerializeField]
        private Button _button;
        [SerializeField]
        private TMP_Text _text;

        private bool _isOpen;

        public Button Button => _button;
        public Plane Plane
        {
            get => _plane;
            set
            {
                _plane = value;
                _Icon.sprite = _plane.Sprite;
                _text.text = _plane.Price.ToString();
            }
        }
        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                _isOpen = value;
                if(_isOpen)
                {
                    _text.text = "open";
                    _frame.color = Color.white;
                }
                else
                {
                    SetPrice(); 
                    _frame.color = Color.gray;
                }
            }
        }

        private void SetPrice()
        {
            if(Plane.PaymentType == Currency.Ad)
            {
                var temp = PlayerProgress.Instance.GetAdPlane(Plane.Id);
               // _text.text = temp != 0 ? temp.ToString() : Plane.Price.ToString();
               _text.text = temp.ToString();
            }
            else
            {
                _text.text = Plane.Price.ToString();
            }
        }

        public void SetCurrent()
        {
            _text.text = "current";
            _frame.color = Color.green;
        }
    }
}
