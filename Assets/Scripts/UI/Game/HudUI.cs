using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Appegy.UI.Game
{
    public class HudUI : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _coinsAmount;
        [SerializeField]
        private TMP_Text _currentStage;

        private GameProgress gameProgress;

        [SerializeField]
        private Button _looseButton;
        [SerializeField]
        private Button _addCoinButton;
        [SerializeField]
        private Button _addScoreButton;
        public Button LooseButton => _looseButton;
        public Button AddCoinButton => _addCoinButton;
        public Button AddScoreButton => _addScoreButton;

        private void OnEnable()
        {
            AddCoinButton.onClick.AddListener(OnAddCoinButtonClick);
            AddScoreButton.onClick.AddListener(OnAddScoreButtonClick);
            _coinsAmount.text = PlayerProgress.Instance.CoinsTotal.ToString();
        }

        private void OnDisable()
        {
            AddCoinButton.onClick.RemoveListener(OnAddCoinButtonClick);
            AddScoreButton.onClick.RemoveListener(OnAddScoreButtonClick);
        }

        public void SetGameProgress(GameProgress gameProgress) 
        { 
            this.gameProgress = gameProgress; 
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
            _currentStage.text = gameProgress.CurrentStage.ToString();
        }
        private void ShowCoinsAmount()
        {
            _coinsAmount.text = PlayerProgress.Instance.CoinsTotal.ToString();
        }
    }
}
