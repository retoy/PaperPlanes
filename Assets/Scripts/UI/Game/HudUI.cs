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

        [SerializeField]
        private Button _looseButton;
        [SerializeField]
        private Button _addCoinButton;
        [SerializeField]
        private Button _addScoreButton;

        [SerializeField]
        private GameProgress _gameProgress;

        public Button LooseButton => _looseButton;

        private void Start()
        {
            _addCoinButton.onClick.AddListener(OnAddCoinButtonClick);
            _addScoreButton.onClick.AddListener(OnAddScoreButtonClick);

            _gameProgress.OnCurrentStageChanged += ShowCurrentStage;
            PlayerProgress.Instance.OnCoinsValueChanged += ShowCoinsAmount;

            _coinsAmount.text = PlayerProgress.Instance.CoinsTotal.ToString();
        }

        private void OnDestroy()
        {
            _addCoinButton.onClick.RemoveListener(OnAddCoinButtonClick);
            _addScoreButton.onClick.RemoveListener(OnAddScoreButtonClick);

            _gameProgress.OnCurrentStageChanged -= ShowCurrentStage;
            PlayerProgress.Instance.OnCoinsValueChanged -= ShowCoinsAmount;
        }

        public void SetGameProgress(GameProgress gameProgress)
        {
            _gameProgress = gameProgress;
        }

        private void OnAddCoinButtonClick()
        {
            PlayerProgress.Instance.CoinsTotal++;
        }

        private void OnAddScoreButtonClick()
        {
            _gameProgress.CurrentStage++;
        }

        private void ShowCurrentStage()
        {
            _currentStage.text = _gameProgress.CurrentStage.ToString();
        }

        private void ShowCoinsAmount()
        {
            _coinsAmount.text = PlayerProgress.Instance.CoinsTotal.ToString();
        }
    }
}
