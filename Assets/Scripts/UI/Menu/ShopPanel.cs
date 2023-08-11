using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Appegy.UI.Menu
{
    public class ShopPanel : MonoBehaviour
    {
        [SerializeField]
        private Button _homeButton;

        public Button HomeButton => _homeButton;
    }
}