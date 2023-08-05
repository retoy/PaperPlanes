using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Appegy.UI.Menu
{
    public class ShopPanel : MonoBehaviour
    {
        [FormerlySerializedAs("homeButton")]
        [SerializeField]
        private Button _homeButton;

        public Button HomeButton => _homeButton;
    }
}