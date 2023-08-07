using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Appegy.UI.Game
{
    public class HudUI : MonoBehaviour
    {
        [SerializeField] 
        private Button looseButton;
        [SerializeField]
        private Button AddCoinButton;
        [SerializeField]
        private Button AddScoreButton;
        [SerializeField]
        private TMP_Text coinsAmount;
        [SerializeField]
        private TMP_Text currentStage;

        [SerializeField]
        private GameObject gameOverPrefab;


        private GameProgress gameProgress;
        private GameObject gameOverPanel;

        private void OnEnable()
        {
            looseButton.onClick.AddListener(OnLooseButtonClick);
            AddCoinButton.onClick.AddListener(OnAddCoinButtonClick);
            AddScoreButton.onClick.AddListener(OnAddScoreButtonClick);

            coinsAmount.text = PlayerProgress.Instance.CoinsTotal.ToString();
        }

        private void OnDisable()
        {
            looseButton.onClick.RemoveListener(OnLooseButtonClick);
            AddCoinButton.onClick.RemoveListener(OnAddCoinButtonClick);
            AddScoreButton.onClick.RemoveListener(OnAddScoreButtonClick);

        }

        public void SetGameProgress(GameProgress gameProgress) 
        { 
            this.gameProgress = gameProgress; 
        }

        private void OnLooseButtonClick()
        {
            gameOverPanel = Instantiate(gameOverPrefab, transform.parent);
            gameOverPanel.SetActive(true);
            gameProgress.SaveProgress();
        }
        private void OnAddCoinButtonClick()
        {
            gameProgress.CoinsCollected++;
            ShowCoinsAmount();
        }
        private void OnAddScoreButtonClick()
        {
            gameProgress.CurrentStage++;
            ShowCurrentStage();
        }

        private void ShowCurrentStage()
        {
            currentStage.text = gameProgress.CurrentStage.ToString();
        }
        private void ShowCoinsAmount()
        {
            coinsAmount.text = PlayerProgress.Instance.CoinsTotal.ToString();
        }
    }
}
