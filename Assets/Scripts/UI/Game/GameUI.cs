using UnityEngine;

namespace Appegy.UI.Game
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private GameObject hudPrefab;
        [SerializeField] private GameProgress gameProgress;
        private void Awake()
        {
            GameObject hud = Instantiate(hudPrefab, transform);
            hud.GetComponent<HudUI>().SetGameProgress(gameProgress);
        }
    }
}
