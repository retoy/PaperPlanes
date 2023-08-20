using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Appegy
{
    public class ShopCell : MonoBehaviour
    {
        [SerializeField]
        private Image _sprite;
        [SerializeField]
        private Button _button;
        [SerializeField]
        private TMP_Text _text;

        public Image Image => _sprite;
        public Button Button => _button;
        public TMP_Text Text => _text;

        private void Start()
        {
                
        }
    }
}
