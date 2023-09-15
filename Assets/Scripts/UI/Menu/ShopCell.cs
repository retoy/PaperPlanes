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
        private Image _frameImage;
        [SerializeField]
        private Button _button;
        [SerializeField]
        private TMP_Text _text;
        [SerializeField]
        private Image _planeImage;

        public Image FrameImage => _frameImage;
        public Image PlaneImage => _planeImage;
        public Button Button => _button;
        public TMP_Text Text => _text;
     
    }
}
