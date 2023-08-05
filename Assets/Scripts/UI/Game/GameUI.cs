using UnityEngine;

namespace Appegy.UI.Game
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private GameObject hudPrefab;
        private void Awake()
        {
            Instantiate(hudPrefab, transform);
        }
    }
}
